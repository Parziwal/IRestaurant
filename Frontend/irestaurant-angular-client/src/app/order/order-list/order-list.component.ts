import { Component } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/authentication/auth.service';
import { UserRole } from 'src/app/authentication/models/user-roles';
import { PagedList } from 'src/app/shared/models/pagedList.type';
import { OrderOverview } from '../models/order-overview.type';
import { OrderSearch } from '../models/order-search.type';
import { OrderSortBy } from '../models/order-sort-by.type';
import { OrderStatus } from '../models/order-status.type';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css'],
})
export class OrderListComponent {
  /** A rendelések áttekintő adatait tartalmazza. */
  orderOverviewPagedList: Observable<PagedList<OrderOverview>> =
    new Observable();

  /** A tabok/fülek nevei. */
  tabsLabelList = ['Összes', 'Folyamatban', 'Lezárva'];

  /** Tabonkénti/fülenkénti lebontásban tartalmazza a lekérdezendő státuszú rendeléseket. */
  tabsStatusList = [
    [
      OrderStatus.PROCESSING,
      OrderStatus.ORDER_COMPLETION,
      OrderStatus.UNDER_DELIVERING,
      OrderStatus.DELIVERED,
      OrderStatus.CANCELLED,
    ],
    [
      OrderStatus.PROCESSING,
      OrderStatus.ORDER_COMPLETION,
      OrderStatus.UNDER_DELIVERING,
    ],
    [OrderStatus.DELIVERED, OrderStatus.CANCELLED],
  ];

  /** A keresési feltétel. */
  search: OrderSearch = <OrderSearch>{
    restaurantName: '',
    guestName: '',
    statuses: this.tabsStatusList[0],
    sortBy: OrderSortBy.PREFFERED_DELIVERY_DATE_DESC,
  };

  constructor(
    private orderService: OrderService,
    private authService: AuthService
  ) {}

  /**
   * A rendelések áttekintő adatainak lekérdezése a felhasználó szerepkörétől függően.
   */
  refreshOrderPagedList() {
    this.authService.currentUserRole.subscribe((role: UserRole) => {
      if (role === UserRole.Guest) {
        this.orderOverviewPagedList =
          this.orderService.getCurrentGuestOrderList(this.search);
      } else if (role === UserRole.Restaurant) {
        this.orderOverviewPagedList = this.orderService.getResturantOrderList(
          this.search
        );
      }
    });
  }

  /**
   * A kiválasztott fül megváltozásakor frissíti a rendeléseket.
   * @param tabChangeEvent A fül megváltozási eseménye.
   */
  selectedTabChanged(tabChangeEvent: MatTabChangeEvent) {
    this.search = {
      ...this.search,
      statuses: this.tabsStatusList[tabChangeEvent.index],
      pageNumber: 1,
      pageSize: 10,
    };
    this.refreshOrderPagedList();
  }

  /**
   * A lapozási adatok változása hatására frissíti a keresési feltételeket és lekéri az új rendelési listát.
   * @param pageOptions A megváltozott lapozási adatok.
   */
  pageOptionsChanged(pageOptions: PageEvent) {
    this.search.pageNumber = pageOptions.pageIndex + 1;
    this.search.pageSize = pageOptions.pageSize;
    this.refreshOrderPagedList();
  }
}
