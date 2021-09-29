import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { CreateOrder } from './models/create-order.type';
import { DeliveryDetials } from './models/delivery-details.type';
import { OrderDetails } from './models/order-details.type';
import { OrderFoodWithId } from './models/order-food-with-id.type';
import { OrderOverview } from './models/order-overview.type';
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
   * A jelenlegi vendég rendeléseinek lekérése.
   * @returns A vendég rendeléseinek listája.
   */
  getCurrentGuestOrderList() {
    return this.http.get<OrderOverview[]>(`${this.orderApiUrl}/guest`).pipe(map(
      (orderOverviews) => {
        return orderOverviews.map(order => {
          order.statusInString = this.getOrderStatusInString(order.status)
          return order;
        });
      }
    ));
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem rendeléseinek lekérése.
   * @returns Az étterem rendeléseinek listája.
   */
  getResturantOrderList() {
    return this.http.get<OrderOverview[]>(`${this.orderApiUrl}/restaurant`).pipe(map(
      (orderOverviews) => {
        return orderOverviews.map(order => {
          order.statusInString = this.getOrderStatusInString(order.status)
          return order;
        });
      }
    ));
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
}
