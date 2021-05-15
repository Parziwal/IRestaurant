import { Component } from '@angular/core';
import { RestaurantSettings } from '../models/restaurant-settings.type';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-restaurant-settings',
  templateUrl: './restaurant-settings.component.html',
  styleUrls: ['./restaurant-settings.component.css']
})
export class RestaurantSettingsComponent {

  /** Az étterem beállítási adatai. */
  restaurantSettings: RestaurantSettings;

  constructor(private restaurantService: RestaurantService) { }

  ngOnInit(): void {
    this.getRestaurantSettings();
  }

  private getRestaurantSettings() {
    this.restaurantService.getMyRestaurantSettings().subscribe(
      (restaurantSettings: RestaurantSettings) => {
        this.restaurantSettings = restaurantSettings;
      }
    );
  }

  /**
   * Az étterem elérhetőségi státuszának megváltozásakor hívódik meg, és elmenti a változtatásokat.
   * Ha az étterem elrejtésre kerül, akkor automatikusan a rendelési lehetőség is kikapcsolásra kerül.
   */
  showForUsersStatusChanged() {
    if (this.restaurantSettings.showForUsers) {
      this.restaurantService.showMyRestaurantForUsers().subscribe(
        ok => {},
        error => {
          this.restaurantSettings.showForUsers = !this.restaurantSettings.showForUsers;
        }
      );
    } else {
      this.restaurantSettings.isOrderAvailable = this.restaurantSettings.showForUsers;
      this.restaurantService.hideMyRestaurantForUsers().subscribe(
        ok => {},
        error => {
          this.restaurantSettings.showForUsers = !this.restaurantSettings.showForUsers
          this.restaurantSettings.isOrderAvailable = this.restaurantSettings.showForUsers;
        }
      );
    }
  }

  /**
   * Az étterem rendelési státuszának megváltozásakor hívódik meg, és elmenti a változtatásokat.
   */
  isOrderAvailableStatusChanged() {
    if (this.restaurantSettings.isOrderAvailable) {
      this.restaurantService.turnOnOrderOption().subscribe(
        ok => {},
        error => {
          this.restaurantSettings.isOrderAvailable = !this.restaurantSettings.isOrderAvailable;
        }
      );
    } else {
      this.restaurantService.turnOffOrderOption().subscribe(
        ok => {},
        error => {
          this.restaurantSettings.isOrderAvailable = !this.restaurantSettings.isOrderAvailable;
        }
      );
    }
  }
}
