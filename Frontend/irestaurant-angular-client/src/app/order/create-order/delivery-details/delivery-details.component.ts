import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { UserAddressWithId } from 'src/app/shared/models/user-address-with-id.type';
import { dateTimeMin } from 'src/app/shared/validators/date-time-min.validator';
import { UserAddressService } from 'src/app/user/user-address.service';
import { OrderService } from '../../order.service';

@Component({
  selector: 'app-delivery-details',
  templateUrl: './delivery-details.component.html',
  styleUrls: ['./delivery-details.component.css']
})
export class DeliveryDetailsComponent implements OnInit {

  /** A kiszállítási adatok űrlapja. */
  deliveryForm!: FormGroup;
  /** A kiválasztott számlázási cím azonosítója. A -1 új címet jelent. */
  selectedAddressId: number = -1;
  /** A vendég számlázási címeit tartalmazó lista. */
  guestAddresses: Observable<UserAddressWithId[]> = new Observable();
  /** Jelzi, ha a felhasználó már megadta a kiszállítási adatait. */
  @Output()  deliveryDetailsCompleted = new EventEmitter<boolean>();
  /** A kívánt kiszállítási időnek minimum a megadott órával a rendelés leadása után kell lennie. */
  minHourAfterOrder: number = 1;
  /** A kívánt kiszállítási időnek megadható minimum dátum. */
  minDateTime: Date = new Date(new Date().setHours(new Date().getHours() + this.minHourAfterOrder));

  constructor(private userAddressService: UserAddressService,
    private orderService: OrderService) { }

  ngOnInit(): void {
    this.initForm();
    this.getGuestAddresses();
  }

  /**
   * A kiszállítási űrlap inicializálása.
   * Minden egyes az űrlapot érintő változásnál megnézzük, hogy a form valid-e, és ennek
   * megfelelően jelezzük, hogy a felhasználó már megadta-e a kiszállítási adatait.
   */
  private initForm() {
    this.deliveryForm = new FormGroup({
        preferredDeliveryDate: new FormControl(null, [Validators.required, dateTimeMin(this.minDateTime)]),
        address: new FormGroup({
          zipCode: new FormControl(null, [Validators.required, Validators.min(1000), Validators.max(9999)]),
          city: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
          street: new FormControl(null, [Validators.required, Validators.maxLength(200)]),
          phoneNumber: new FormControl(null, [Validators.required, Validators.pattern("[0-9]{2}-[0-9]{2}-[0-9]{3}-[0-9]{4}")])
        })
    });

    this.deliveryForm.valueChanges.subscribe(() => {
      if (this.deliveryForm.valid) {
        this.deliveryDetailsCompleted.emit(true);
      } else {
        this.deliveryDetailsCompleted.emit(false);
      }
    });
  }

  private getGuestAddresses() {
    this.guestAddresses = this.userAddressService.getCurrentGuestAddressList();
  }

  /**
   * Ha a vendég kiválasztott egy címet a listából, akkor a form cím részének szerkesztését letiltjuk,
   * és betöltjük a kiválasztott címet. Ha pedig null a megadott paraméter, akkor kiürítjük a form
   * cím részét és újra engedélyezzük a szerkesztést.
   * @param address A vendég számlázási/szállítási címe. Ha null, akkor az azt jelenti, hogy a vendég új címet akat felvenni,
   */
  onAddressSelected(address: UserAddressWithId | null) {
    if (address == null) {
      this.deliveryForm.controls.address.reset();
      this.deliveryForm.controls.address.enable();
      return;
    }

    this.deliveryForm.controls.address.patchValue({
      zipCode: address.zipCode,
      city: address.city,
      street: address.street,
      phoneNumber: address.phoneNumber
    });
    this.deliveryForm.controls.address.disable();
  }

    /**
   * A paraméterként átadott vezérlő neve alapján a hozzá tartozó hibaüzenet lekérdezése.
   * @param controlName A vezérlő neve.
   * @returns A hibaüzenet.
   */
  getErrorMessage(controlName: string) {
    if (this.deliveryForm.get(controlName)?.hasError("required")) {
      return "A mező kitöltése kötelező!";
    }
    if (this.deliveryForm.get(controlName)?.hasError("maxlength")) {
      return `A mező értéke nem lépheti át a(z) ${this.deliveryForm.get(controlName)?.errors?.maxlength.requiredLength} karakteres limitet!`;
    }
    if (this.deliveryForm.get(controlName)?.hasError("min")) {
      return `A mező értéke nem lehet kisebb mint ${this.deliveryForm.get(controlName)?.errors?.min.min}!`;
    }
    if (this.deliveryForm.get(controlName)?.hasError("dateTimeMin")) {
      return `A kívánt kiszállítási időnek minimum ${this.minHourAfterOrder} órával a rendelés leadása után kell lennie!`;
    }

    return null;
  }

  /**
   * Az űrlap elküldése. Ha a kiválasztott cím azonosítója -1, akkor az azt jelenti, hogy a vendég egy új
   * címet vett fel és ezesetben először létrehozzuk a címet, majd jelezzük, hogy a rendelési adatok megváltoztak.
   * Ha a kiválasztott cím azonosítója nem -1, akkor simán jelezzük, hogy a rendelési adatok megváltoztak.
   */
  onSubmit() {
    if (this.selectedAddressId == -1) {
      this.userAddressService.createUserAddress(this.deliveryForm.controls.address.value).subscribe(
        (createdAddress: UserAddressWithId) => {
          this.changeDeliveryDetails(createdAddress.id);
        }
      );
    } else {
      this.changeDeliveryDetails(this.selectedAddressId);
    }
  }

  private changeDeliveryDetails(addressId: number) {
    this.orderService.deliveryDetailsChange.next(
      {
        ...this.deliveryForm.value, 
        address: {
          ...this.deliveryForm.controls.address.value,
          id: addressId 
    }});
  }
}

