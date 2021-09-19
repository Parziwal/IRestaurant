import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { RestaurantOverview } from '../../models/restaurant-overview.type';

@Component({
  selector: 'app-restaurant-list-item',
  templateUrl: './restaurant-list-item.component.html',
  styleUrls: ['./restaurant-list-item.component.css']
})
export class RestaurantListItemComponent {

  @Input() restaurantOverview!: RestaurantOverview;
  defaultRestaurantImgUrl = environment.defaultRestaurantImgUrl;

  constructor(private router: Router) { }

  onItemClicked() {
    this.router.navigate(['/restaurant/details', this.restaurantOverview.id]);
  }
}
