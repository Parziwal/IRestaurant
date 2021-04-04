import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { RestaurantOverview } from '../models/restaurant-overview.type';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.css']
})
export class RestaurantListComponent implements OnInit {

  restaurantOverviews: Observable<RestaurantOverview[]> = new Observable();

  constructor(private restaurantService: RestaurantService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getRestaurantList();

  }

  private getRestaurantList() {
    this.route.url.subscribe(
      (urlSegment) => {
        if (urlSegment.length > 1 && urlSegment[1].path === "favourite") {
          this.restaurantOverviews = this.restaurantService.getGuestFavouriteRestaurantList();
        } else {
          this.restaurantOverviews = this.restaurantService.getRestaurantList();
        }
      }
    );
  }

}
