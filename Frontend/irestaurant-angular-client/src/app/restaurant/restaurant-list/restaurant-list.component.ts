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

  /** Az étterem áttekintő adatai. */
  restaurantOverviews: Observable<RestaurantOverview[]> = new Observable();
  /** A keresési kifejezés. */
  searchTerm!: string;
  /** Törlési ikon. */
  faTimes = faTimes;
  private restaurantListType: RestaurantListType = RestaurantListType.All;

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

  /**
   * A megadott névre illeszkedő éttermek áttekintő adatainak lekérdezése.
   * A lista típusától függően, amit az útvonal adat része tartalmaz, az összes étterem,
   * vagy csak az aktuális vendég kedvenceinek lekérése.
   */
  getRestaurantList() {
    let options = {searchTerm: this.searchTerm};
    if (this.restaurantListType === RestaurantListType.Favourite) {
      this.restaurantOverviews = this.restaurantService.getGuestFavouriteRestaurantList(options);
    } else {
      this.restaurantOverviews = this.restaurantService.getRestaurantList(options);
    } 
  }

  /**
   * A kereső mező törlése és az éttermek listájának frissítése.
   */
  clearBrowser() {
    this.searchTerm = "";
    this.getRestaurantList();
  }
}
