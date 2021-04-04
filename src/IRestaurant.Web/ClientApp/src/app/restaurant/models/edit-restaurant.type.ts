import { Address } from "src/app/shared/models/address.type";

export interface EditRestaurant {
    name: string;
    shortDescription: string;
    detailedDescription: string;
    address: Address;
    image: File;
}