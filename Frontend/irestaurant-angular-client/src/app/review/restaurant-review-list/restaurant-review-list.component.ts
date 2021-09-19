import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/authentication/auth.service';
import { UserRole } from 'src/app/authentication/user-roles';
import { Review } from '../models/review.type';
import { ReviewService } from '../review.service';
import { AddReviewDialogComponent } from './add-review-dialog/add-review-dialog.component';

@Component({
  selector: 'app-restaurant-review-list',
  templateUrl: './restaurant-review-list.component.html',
  styleUrls: ['./restaurant-review-list.component.css']
})
export class RestaurantReviewListComponent implements OnInit {

  /** Az étterem azonosítója, akinek az értékelésit lekérdezzük. */
  @Input() restaurantId: number = -1;
  /** Az étterem aggregált értékelése. */
  @Input() restaurantRating: number = 1;
  /** Az étteremhez tartozó értékelések. */
  reviews: Observable<Review[]> = new Observable();
  /** Az értékelések száma. */
  reviewsCount: number = 0;
  /** Az aktuális felhasználó szerepköre. */
  userRole!: Observable<UserRole>;

  constructor(private reviewService: ReviewService,
    private authService: AuthService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getReviews();
    this.getCurrentUserRole();
  }

  private getCurrentUserRole() {
    this.userRole = this.authService.currentUserRole;
  }

  private getReviews() {
    this.reviews = this.reviewService.getRestaurantReviews(this.restaurantId);
  }

  /**
   * A jelenlegi étteremhez értékelés létrehozása egy dialógus ablak segítségével.
   * Ha az értékelés létrehozása sikeres volt frissítjük az értékelések listáját. 
   */
  addReviewClicked() {
    const dialogRef = this.dialog.open(AddReviewDialogComponent, {
      data: this.restaurantId,
      width: "500px"
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getReviews();
      }
    });
  }
}
