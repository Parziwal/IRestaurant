import { Address } from "src/app/shared/models/address.type";

export interface RestaurantDetails {
    id: number;
    name: string;
    rating: number;
    shortDescription: string;
    detailedDescription: string;
    imagePath: string;
    restaurantAddress: Address;
    ownerName: string;
    isOrderAvailable: boolean;
    isCurrentGuestFavourite: boolean;
}