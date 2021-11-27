import {
  Component,
  EventEmitter,
  OnDestroy,
  OnInit,
  Output,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { UserAddressWithId } from 'src/app/shared/models/user-address-with-id.type';
import { GuestAddressService } from '../../guest-address.service';
import { CreateOrderFood } from '../../models/create-order-food.type';
import { CreateOrder } from '../../models/create-order.type';
import { DeliveryDetials } from '../../models/delivery-details.type';
import { OrderDetails } from '../../models/order-details.type';
import { OrderFoodWithId } from '../../models/order-food-with-id.type';
import { OrderService } from '../../order.service';

@Component({
  selector: 'app-order-finalization',
  templateUrl: './order-finalization.component.html',
  styleUrls: ['./order-finalization.component.css'],
})
export class OrderFinalizationComponent implements OnInit, OnDestroy {
  /** A kiszállítási adatok. */
  deliveryDetails!: DeliveryDetials;

  /** A vendég által kiválasztott ételek listája. */
  orderFoods: OrderFoodWithId[] = [];

  /** A rendelés véglegesítésnek jelzése és a rendelési azonosító átadása. */
  @Output() orderFinalizationCompleted = new EventEmitter<number>();

  private orderFoodsChangeSub!: Subscription;
  private deliveryDetailsChangeSub!: Subscription;

  constructor(
    private orderService: OrderService,
    private guestAddressService: GuestAddressService,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.subscribeToOrderDataChange();
  }

  ngOnDestroy(): void {
    this.orderFoodsChangeSub.unsubscribe();
    this.deliveryDetailsChangeSub.unsubscribe();
  }

  /**
   * A rendelés összértékének kiszámítása.
   */
  get orderFoodsTotal(): number {
    let total = 0;
    this.orderFoods.forEach((f) => {
      total += f.price * f.amount;
    });
    return total;
  }

  private subscribeToOrderDataChange() {
    this.orderFoodsChangeSub = this.orderService.chosenFoodsChanged.subscribe(
      (orderFoods: OrderFoodWithId[]) => {
        this.orderFoods = orderFoods;
      }
    );
    this.deliveryDetailsChangeSub =
      this.orderService.deliveryDetailsChanged.subscribe(
        (deliveryDetails: DeliveryDetials) => {
          this.deliveryDetails = deliveryDetails;
        }
      );
  }

  /**
   * A rendelés létrehozása a felhasználó által megadott adatok alapján.
   * Ha a lakcím azonosító -1, akkor az azt jelenti, hogy a felhasználó új lakcímet adott le,
   * így a rendelés létrehozása előtt elmentjük a lakcímet.
   */
  onOrderClicked() {
    if (this.deliveryDetails.address.id === -1) {
      this.guestAddressService
      .createUserAddress(this.deliveryDetails.address)
      .subscribe((createdAddress: UserAddressWithId) => {
        this.deliveryDetails.address.id = createdAddress.id;
        this.createOrder();
      });
      return;
    }

    this.createOrder();
  }

  private createOrder() {
    let createdOrder = <CreateOrder>{
      preferredDeliveryDate: this.deliveryDetails.preferredDeliveryDate,
      addressId: this.deliveryDetails.address.id,
      restaurantId: this.route.snapshot.params.id,
      orderFoods: this.orderFoods.map(
        (of) => <CreateOrderFood>{ foodId: of.id, amount: of.amount }
      ),
    };
    this.orderService
      .createOrder(createdOrder)
      .subscribe((createdOrder: OrderDetails) => {
        this.toastr.success('A rendelés rögzítése megtörtént.');
        this.orderFinalizationCompleted.emit(createdOrder.id);
      });
  }
}
