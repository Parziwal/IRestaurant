import { OrderStatus } from "./order-status.type";

export interface OrderOverview {
    id: number;
    date: Date;
    preferredDeliveryDate: Date;
    status: OrderStatus;
    statusInString: string,
    total: number;
    userFullName: string;
    restaurantName: string;
}