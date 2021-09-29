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

  /** Az étterem áttekintő adatai. */
  @Input() restaurantOverview!: RestaurantOverview;

  constructor(private router: Router) { }

  /**
   * A felhasználó átnavigálása az étteremhez tartozó részletes oldalra.
   */
  onItemClicked() {
    this.router.navigate(['/restaurant/details', this.restaurantOverview.id]);
  }
}
