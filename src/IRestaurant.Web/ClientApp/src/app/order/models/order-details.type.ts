import { Address } from "src/app/shared/models/address.type";
import { OrderFood } from "./order-food.type";

export interface OrderDetails {
    id: number;
    date: Date;
    preferredDeliveryDate: Date;
    status: number;
    statusInString: string;
    total: number;
    userFullName: string;
    userAddress: Address;
    restaurantName: string;
    restaurantAddress: Address;
    orderFoods: OrderFood[];
}