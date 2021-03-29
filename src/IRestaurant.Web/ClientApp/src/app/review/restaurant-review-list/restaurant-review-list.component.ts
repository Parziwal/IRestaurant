import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs';
import { Review } from '../models/review.type';
import { ReviewService } from '../review.service';
import { AddReviewDialogComponent } from './add-review-dialog/add-review-dialog.component';

@Component({
  selector: 'app-restaurant-review-list',
  templateUrl: './restaurant-review-list.component.html',
  styleUrls: ['./restaurant-review-list.component.css']
})
export class RestaurantReviewListComponent implements OnInit {

  private restaurantId: number;
  reviews: Observable<Review[]> = new Observable();
  reviewsCount: number = 0;
  @Input()
  reviewsAvarageRating: number = 1;

  constructor(private reviewService: ReviewService,
    private route: ActivatedRoute,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getReviews();
  }

  private getReviews() {
    this.route.params.subscribe(
      (params: Params) => {
        this.restaurantId = +params['id'];
        this.reviews = this.reviewService.getRestaurantReviews(this.restaurantId);
      }
    );
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
