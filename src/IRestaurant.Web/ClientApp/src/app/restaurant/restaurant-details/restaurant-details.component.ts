import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RestaurantDetails } from '../models/restaurant-details.type';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent implements OnInit, OnDestroy {

  restaurant: RestaurantDetails;
  private restaurantId;
  private ratingChangedSub = new Subscription();

  constructor(private restaurantService: RestaurantService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getRestaurantId();
    this.subscribeToRatingChanged();
  }

  ngOnDestroy(): void {
    this.ratingChangedSub.unsubscribe();
  }

  private getRestaurantId() {
    this.route.params.subscribe(
      (params: Params) => {
        this.restaurantId = +params['id'];
        this.getRestaurantDetails();
      }
    );
  }

  private subscribeToRatingChanged() {
    this.ratingChangedSub = this.restaurantService.restaurantRatingChanged.subscribe(() =>
      this.getRestaurantDetails()
    );
  }

  private getRestaurantDetails() {
    this.restaurantService.getRestaurantDetails(this.restaurantId).subscribe(
      (restaurantData: RestaurantDetails) => { 
        this.restaurant = restaurantData;
        if (this.restaurant.imagePath == null) {
          this.restaurant.imagePath = environment.defaultRestaurantImgUrl;
        }
      }
    );
  }

}
