import { Pipe, PipeTransform } from '@angular/core';
import { OrderOverview } from '../../models/order-overview.type';
import { OrderStatus } from '../../models/order-status.type';

@Pipe({
  name: 'inProgressOrders'
})
export class InProgressOrdersPipe implements PipeTransform {

  /**
   * A paraméterként kapott rendelések közül a még folyamatban lévőek lekérdezése.
   * @param orderOverviews A rendelések áttekintő adatainak listája.
   * @returns A folyamatban lévő rendelések.
   */
  transform(orderOverviews: OrderOverview[]): OrderOverview[] {
    if (orderOverviews == null) {
      return null;
    }
    return orderOverviews.filter(order =>
      order.status == OrderStatus.PROCESSING || 
      order.status == OrderStatus.ORDER_COMPLETION ||
      order.status == OrderStatus.UNDER_DELIVERING);
  }
}
