import { Component, EventEmitter, Input, Output } from '@angular/core';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { RestaurantSearch } from '../../models/restaurant-search.type';
import { RestaurantSortBy } from '../../models/restaurant-sort-by.type';
import { RestaurantService } from '../../restaurant.service';

@Component({
  selector: 'app-restaurant-search-bar',
  templateUrl: './restaurant-search-bar.component.html',
  styleUrls: ['./restaurant-search-bar.component.css']
})
export class RestaurantSearchBarComponent {

  /** Törlési ikon. */
  faTimes = faTimes;
  /** A keresési feltétel. */
  @Input() search: RestaurantSearch = <RestaurantSearch>{};
  /** Az étterem lista frissítésére vonatkozó esemény. */
  @Output() refreshRestaurantList = new EventEmitter<void>();
  /** A lehetséges rendezési szempontokat tartalmazó lista. */
  restaurantSortByOptions = Object.keys(RestaurantSortBy)
    .map(s => ({
      value: s,
      text: this.restaurantService.getRestaurantSortByInString(s as RestaurantSortBy)
    }));

  constructor(private restaurantService: RestaurantService) { }
                                
  /**
   * A kereső mező törlése és az éttermek listájának frissítése.
   */
  clearBrowser() {
    this.search.nameOrShortDescriptionOrCity = "";
    this.refreshRestaurantList.emit();
  }
}
