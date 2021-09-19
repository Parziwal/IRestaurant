import { OrderFood } from "./order-food.type";

export interface OrderFoodWithId extends OrderFood {
    id: number;
}