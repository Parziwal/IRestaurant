import { Pipe, PipeTransform } from '@angular/core';
import { OrderOverview } from '../../models/order-overview.type';
import { OrderStatus } from '../../models/order-status.type';

@Pipe({
  name: 'closedOrders'
})
export class ClosedOrdersPipe implements PipeTransform {

  transform(orderOverviews: OrderOverview[]): OrderOverview[] {
    if (orderOverviews == null) {
      return null;
    }
    return orderOverviews.filter(order =>
      order.status == OrderStatus.DELIVERED || 
      order.status == OrderStatus.CANCELLED);
  }
}
