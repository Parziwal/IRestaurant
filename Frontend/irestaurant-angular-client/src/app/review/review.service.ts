import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateReview } from './models/create-review.type';
import { Review } from './models/review.type';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  private reviewAPIURL = environment.webAPIURL + "/review";

  constructor(private http: HttpClient) { }

  /**
   * A megadott azonosítójú étteremhez tartozó értékelések lekérése.
   * @param restaurantId Az étterem azonosítója.
   * @returns Az étterem értékeléseinek listája.
   */
  getRestaurantReviews(restaurantId: number) {
    return this.http.get<Review[]>(`${this.reviewAPIURL}/restaurant/${restaurantId}`);
  }

  /**
   * Az aktuális vendég által írt értékelések megjelenítése.
   * @returns Az aktuális vendég értékelései.
   */
  getCurrentGuestReviews() {
    return this.http.get<Review[]>(`${this.reviewAPIURL}/myreviews`);
  }

  /**
   * Értékelés létrehozása az aktuális vendég által a megadott adatok alapján.
   * @param createdReview A létrehozandó értékelés.
   * @returns A létrehozott értékelés.
   */
  addReviewToRestaurant(createdReview: CreateReview) {
    return this.http.post<Review>(this.reviewAPIURL, createdReview);
  }

  /**
   * A megadott azonosítójú értékelés törlése.
   * @param reviewId Az értékelés azonosítója.
   */
  deleteReview(reviewId: number) {
    return this.http.delete(`${this.reviewAPIURL}/${reviewId}`);
  }
}
