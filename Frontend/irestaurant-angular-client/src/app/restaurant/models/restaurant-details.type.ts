import { UserAddress } from "src/app/shared/models/user-address.type";

export interface RestaurantDetails {
    id: number;
    name: string;
    rating: number;
    shortDescription: string;
    detailedDescription: string;
    imagePath: string;
    restaurantAddress: UserAddress;
    ownerFullName: string;
    isOrderAvailable: boolean;
    isCurrentGuestFavourite: boolean;
}