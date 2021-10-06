import { UserAddress } from 'src/app/shared/models/user-address.type';
import { OrderFood } from './order-food.type';

export interface OrderDetails {
  id: number;
  createdAt: Date;
  preferredDeliveryDate: Date;
  status: number;
  statusInString: string;
  total: number;
  userFullName: string;
  userAddress: UserAddress;
  restaurantName: string;
  restaurantAddress: UserAddress;
  orderFoods: OrderFood[];
}
