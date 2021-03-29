import { Component, Input, OnInit } from '@angular/core';
import { Review } from '../../models/review.type';

@Component({
  selector: 'app-restaurant-review-list-item',
  templateUrl: './restaurant-review-list-item.component.html',
  styleUrls: ['./restaurant-review-list-item.component.css']
})
export class RestaurantReviewListItemComponent implements OnInit {

  @Input()
  review: Review

  constructor() { }

  ngOnInit(): void {
  }

}
