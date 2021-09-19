import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/authentication/auth.service';
import { UserRole } from 'src/app/authentication/user-roles';
import { OrderOverview } from '../models/order-overview.type';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

  /** A rendelések áttekintő adatainak listája. */
  orderOverviews: Observable<OrderOverview[]> = new Observable<OrderOverview[]>();

  constructor(private orderService: OrderService,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.getOrderList();
  }

  /**
   * A rendelések áttekintő adatainak lekérdezése a felhasználó szerepkörétől függően.
   */
  private getOrderList() {
    this.authService.currentUserRole.subscribe(
      (role: UserRole) => {
        if (role === UserRole.Guest) {
          this.orderOverviews = this.orderService.getCurrentGuestOrderList();
        } else if (role === UserRole.Restaurant) {
          this.orderOverviews = this.orderService.getResturantOrderList();
        }
      }
    );
  }
}
