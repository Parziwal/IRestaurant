import { Review } from "./review.type";

export interface GuestReview {
    id: number;
    reviewedRestaurantId: number;
    reviewedRestaurantName: string;
    rating: number;
    title: string;
    createdAt: Date;
    description: string;
}