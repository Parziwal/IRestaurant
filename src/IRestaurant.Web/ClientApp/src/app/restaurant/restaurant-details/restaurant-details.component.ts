import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { UserRole } from 'src/api-authorization/api-authorization.constants';
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
  restaurantId: number;
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
    let restaurantDetails: Observable<RestaurantDetails>;
    if (this.route.snapshot.data.role === UserRole.Restaurant) {
      restaurantDetails = this.restaurantService.getMyRestaurantDetails().pipe(tap(
        (restaurantData: RestaurantDetails) => {
          this.restaurantId = restaurantData.id;
        }
      ));
    } else {
      restaurantDetails = this.restaurantService.getRestaurantDetails(this.restaurantId);
    }
    restaurantDetails.subscribe(
      (restaurantData: RestaurantDetails) => { 
        this.restaurant = restaurantData;
        if (this.restaurant.imagePath == null) {
          this.restaurant.imagePath = environment.defaultRestaurantImgUrl;
        }
      }
    );
  }

}
