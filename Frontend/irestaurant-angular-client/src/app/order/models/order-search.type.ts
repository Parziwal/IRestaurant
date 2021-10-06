import { Page } from "src/app/shared/models/page.type";
import { OrderSortBy } from "./order-sort-by.type";
import { OrderStatus } from "./order-status.type";

export interface OrderSearch extends Page {
    restaurantName: string;
    guestName: string;
    statuses: Array<OrderStatus>;
    sortBy: OrderSortBy;
    orderMinDate: string;
    orderMaxDate?: string;
}