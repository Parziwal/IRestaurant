import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs';
import { UserRole } from 'src/api-authorization/api-authorization.constants';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Review } from '../models/review.type';
import { ReviewService } from '../review.service';
import { AddReviewDialogComponent } from './add-review-dialog/add-review-dialog.component';

@Component({
  selector: 'app-restaurant-review-list',
  templateUrl: './restaurant-review-list.component.html',
  styleUrls: ['./restaurant-review-list.component.css']
})
export class RestaurantReviewListComponent implements OnInit {

  @Input() restaurantId: number = -1;
  @Input() restaurantRating: number = 1;
  reviews: Observable<Review[]> = new Observable();
  reviewsCount: number = 0;
  userRole: Observable<UserRole>;

  constructor(private reviewService: ReviewService,
    private authorizeService: AuthorizeService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getReviews();
    this.getCurrentUserRole();
  }

  private getCurrentUserRole() {
    this.userRole = this.authorizeService.getUserRole();
  }

  private getReviews() {
    this.reviews = this.reviewService.getRestaurantReviews(this.restaurantId);
  }

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
