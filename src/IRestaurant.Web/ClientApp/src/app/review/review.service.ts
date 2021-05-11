import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateReview } from './models/create-review.type';
import { Review } from './models/review.type';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  private baseUrl = environment.apiUrl + "review/";

  constructor(private http: HttpClient) { }

  getRestaurantReviews(restaurantId: number) {
    return this.http.get<Review[]>(this.baseUrl + "restaurant/" + restaurantId);
  }

  getCurrentGuestReviews() {
    return this.http.get<Review[]>(this.baseUrl + "myreviews");
  }

  addReviewToRestaurant(restaurantId: number, createdReview: CreateReview) {
    return this.http.post<Review>(this.baseUrl + "restaurant/" + restaurantId, createdReview);
  }

  deleteReview(reviewId: number) {
    return this.http.delete(this.baseUrl + reviewId);
  }
}
