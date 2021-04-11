import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { OrderDetails } from './models/order-details.type';
import { OrderOverview } from './models/order-overview.type';
import { OrderStatus } from './models/order-status.type';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private baseUrl = environment.apiUrl + "orders/";

  constructor(private http: HttpClient) { }

  getCurrentGuestOrderList() {
    return this.http.get<OrderOverview[]>(this.baseUrl + "guest").pipe(map(
      (orderOverviews) => {
        return orderOverviews.map(order => {
          order.statusInString = this.getOrderStatusInString(order.status)
          return order;
        });
      }
    ));
  }

  getResturantOrderList() {
    return this.http.get<OrderOverview[]>(this.baseUrl + "restaurant").pipe(map(
      (orderOverviews) => {
        return orderOverviews.map(order => {
          order.statusInString = this.getOrderStatusInString(order.status)
          return order;
        });
      }
    ));
  }

  getOrderDetails(orderId: number) {
    return this.http.get<OrderDetails>(this.baseUrl + orderId).pipe(map(
      (orderDetails) => {
        orderDetails.statusInString = this.getOrderStatusInString(orderDetails.status);
        return orderDetails;
      }
    ));
  }

  setOrderStatus(orderId: number, status: OrderStatus) {
    let params = new HttpParams();
    params = params.append("status", status.toString());
    return this.http.patch(this.baseUrl + orderId, null, {
      params: params
    });
  }

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
