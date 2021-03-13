import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { environment } from 'src/environments/environment';
import { RestaurantDetails } from '../models/restaurant-details.type';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent implements OnInit {

  restaurant: RestaurantDetails;

  constructor(private restaurantService: RestaurantService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        let id = +params['id'];
        this.restaurantService.getRestaurantDetails(id).subscribe(
          (restaurantData: RestaurantDetails) => { 
            this.restaurant = restaurantData;
            if (this.restaurant.imagePath == null) {
              this.restaurant.imagePath = environment.defaultRestaurantImgUrl;
            }
          }
        );
      }
    );
  }

}
