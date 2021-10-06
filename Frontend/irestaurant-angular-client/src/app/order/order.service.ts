import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PagedList } from '../shared/models/pagedList.type';
import { CreateOrder } from './models/create-order.type';
import { DeliveryDetials } from './models/delivery-details.type';
import { OrderDetails } from './models/order-details.type';
import { OrderFoodWithId } from './models/order-food-with-id.type';
import { OrderOverview } from './models/order-overview.type';
import { OrderSearch } from './models/order-search.type';
import { OrderSortBy } from './models/order-sort-by.type';
import { OrderStatus } from './models/order-status.type';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private orderApiUrl = environment.webApiUrl + "/api/order";
  /** A rendelés létrehozásakor megadott ételek változásának jelzése. */
  chosenFoodsChange = new Subject<OrderFoodWithId[]>();
  /** A kiszállítási adatok megváltozásának jelzése. */
  deliveryDetailsChange = new Subject<DeliveryDetials>();

  constructor(private http: HttpClient) { }

  /**
   * Az átadott API URL-ről lekéri a megadott keresési feltételre illeszkedő éttermek áttekintő adatait.
   * @param apiUrl A API elérési útja.
   * @param search A keresési feltételeket tartalmazza.
   * @returns A rendelések listája.
   */
  private getOrderListBase(apiUrl: string, search?: OrderSearch) {
    return this.http.get<PagedList<OrderOverview>>(apiUrl, {
        params: new HttpParams({fromObject: search as any})
      })
      .pipe(map(
      pagedList => {
        pagedList.result.map(order => {
          order.statusInString = this.getOrderStatusInString(order.status)
          return order;
        });
        return pagedList;
      }
    ));
  }

  /**
   * A jelenlegi vendég rendeléseinek lekérése a keresési feltétel alapján.
   * @param search A keresési feltételeket tartalmazza.
   * @returns A vendég rendeléseinek listája.
   */
  getCurrentGuestOrderList(search?: OrderSearch) {
    return this.getOrderListBase(`${this.orderApiUrl}/guest`, search)
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem rendeléseinek lekérése a keresési feltétel alapján.
   * @param search A keresési feltételeket tartalmazza.
   * @returns Az étterem rendeléseinek listája.
   */
  getResturantOrderList(search?: OrderSearch) {
    return this.getOrderListBase(`${this.orderApiUrl}/restaurant`, search);
  }

  /**
   * A megadott azonosítójú rendelés részletes adatainak lekérése.
   * @param orderId A rendelés azonosítója.
   * @returns A rendelés részletes adatai.
   */
  getOrderDetails(orderId: number) {
    return this.http.get<OrderDetails>(`${this.orderApiUrl}/${orderId}`).pipe(map(
      (orderDetails) => {
        orderDetails.statusInString = this.getOrderStatusInString(orderDetails.status);
        return orderDetails;
      }
    ));
  }

  /**
   * A megadott rendelés státuszának módosítása.
   * @param orderId A rendelés azonosítója.
   * @param status A beállítandó státusz.
   */
  setOrderStatus(orderId: number, status: OrderStatus) {
    let params = new HttpParams();
    params = params.append("status", status.toString());
    return this.http.patch(`${this.orderApiUrl}/${orderId}`, null, {
      params: params
    });
  }

  /**
   * A paraméterként megadott rendelés létrehozása.
   * @param createdOrder A létrehozandó rendelés adatai.
   * @returns A létrehozott rendelés részletes adatai.
   */
  createOrder(createdOrder: CreateOrder) {
    return this.http.post<OrderDetails>(this.orderApiUrl, createdOrder);
  }

  /**
   * A megadott státuszhoz tartozó szöveg lekérdezése.
   * @param status A státusz.
   * @returns A státusz szövege.
   */
  getOrderStatusInString(status: OrderStatus) {
    switch(status) {
      case OrderStatus.PROCESSING:
        return "Feldolgozás alatt";
      case OrderStatus.ORDER_COMPLETION:
        return "Rendelés összeállítása";
      case OrderStatus.UNDER_DELIVERING:
        return "Kiszállítás alatt";
      case OrderStatus.DELIVERED:
        return "Kiszállítva";
      case OrderStatus.CANCELLED:
        return "Lemondva";
    }
  }

  /**
   * A megadott rendezéshez tartozó szöveg lekérdezése.
   * @param status A rendezés sorrendje.
   * @returns A rendezés sorrendjének szövege.
   */
  getOrderSortByInString(sortBy: OrderSortBy) {
    switch(sortBy) {
      case OrderSortBy.CREATED_AT_ASC:
        return "Rendelési dátum ↑";
      case OrderSortBy.CREATED_AT_DESC:
        return "Rendelési dátum ↓";
      case OrderSortBy.PREFFERED_DELIVERY_DATE_ASC:
        return "Kívánt kiszállítási dátum ↑";
      case OrderSortBy.PREFFERED_DELIVERY_DATE_DESC:
        return "Kívánt kiszállítási dátum ↓";
    }
  }
}
