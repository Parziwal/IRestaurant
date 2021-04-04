import { Component, OnInit } from '@angular/core';
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

  constructor(private restaurantService: RestaurantService) { }

  ngOnInit(): void {
    this.getRestaurantList();
  }

  private getRestaurantList() {
    this.restaurantOverviews = this.restaurantService.getRestaurantList();
  }

}
