import { CreateOrderFood } from "./create-order-food.type";

export interface CreateOrder {
    preferredDeliveryDate: Date;
    addressId: number;
    restaurantId: number;
    orderFoods: CreateOrderFood[];
}