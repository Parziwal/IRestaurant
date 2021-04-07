import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {faTimes } from '@fortawesome/free-solid-svg-icons';
import { Observable } from 'rxjs';
import { RestaurantListType } from '../models/restaurant-list-type.type';
import { RestaurantOverview } from '../models/restaurant-overview.type';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.css']
})
export class RestaurantListComponent implements OnInit {

  restaurantOverviews: Observable<RestaurantOverview[]> = new Observable();
  private restaurantListType: RestaurantListType = RestaurantListType.All;
  searchTerm: string;
  faTimes = faTimes

  constructor(private restaurantService: RestaurantService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getRouteData();
  }

  private getRouteData() {
    this.route.data.subscribe(
      (data) => {
        if (data.restaurantListType) {
          this.restaurantListType = data.restaurantListType;
        }
        this.getRestaurantList();
      }
    );
  }

  getRestaurantList() {
    let options = {searchTerm: this.searchTerm};
    if (this.restaurantListType === RestaurantListType.Favourite) {
      this.restaurantOverviews = this.restaurantService.getGuestFavouriteRestaurantList(options);
    } else {
      this.restaurantOverviews = this.restaurantService.getRestaurantList(options);
    } 
  }

  clearBrowser() {
    this.searchTerm = "";
    this.getRestaurantList();
  }
}
