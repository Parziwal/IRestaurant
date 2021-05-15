import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { filter } from 'rxjs/operators';
import { UserRole } from 'src/api-authorization/api-authorization.constants';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { transform } from 'typescript';
import { OrderOverview } from '../models/order-overview.type';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

  /** A rendelések áttekintő adatainak listája. */
  orderOverviews: Observable<OrderOverview[]> = new Observable();

  constructor(private orderService: OrderService,
    private authorizeService: AuthorizeService) { }

  ngOnInit(): void {
    this.getOrderList();
  }

  /**
   * A rendelések áttekintő adatainak lekérdezése a felhasználó szerepkörétől függően.
   */
  private getOrderList() {
    this.authorizeService.getUserRole().subscribe(
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
