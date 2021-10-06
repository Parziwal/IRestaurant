import { OrderStatus } from './order-status.type';

export interface OrderOverview {
  id: number;
  createdAt: Date;
  preferredDeliveryDate: Date;
  status: OrderStatus;
  statusInString: string;
  total: number;
  userFullName: string;
  restaurantName: string;
}
