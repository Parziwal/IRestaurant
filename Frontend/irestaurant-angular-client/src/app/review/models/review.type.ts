export interface Review {
    id: number;
    rating: number;
    title: string;
    createdAt: Date;
    description: string;
    userId: string;
    userFullName: string;
    restaurantId: number;
    restaurantName: string;
}