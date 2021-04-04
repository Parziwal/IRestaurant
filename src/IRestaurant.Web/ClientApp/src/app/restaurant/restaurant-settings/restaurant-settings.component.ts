import { Component } from '@angular/core';
import { RestaurantSettings } from '../models/restaurant-settings.type';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-restaurant-settings',
  templateUrl: './restaurant-settings.component.html',
  styleUrls: ['./restaurant-settings.component.css']
})
export class RestaurantSettingsComponent {
  showForUsers = false;
  isOrderAvailable = false;

  constructor(private restaurantService: RestaurantService) { }

  ngOnInit(): void {
    this.getRestaurantSettings();
  }

  private getRestaurantSettings() {
    this.restaurantService.getMyRestaurantSettings().subscribe(
      (settings: RestaurantSettings) => {
        this.showForUsers = settings.showForUsers;
        this.isOrderAvailable = settings.isOrderAvailable;
      }
    );
  }

  showForUsersStatusChanged() {
    this.isOrderAvailable = this.showForUsers;
    if (this.showForUsers) {
      this.restaurantService.ShowMyRestaurantForUsers().subscribe(
        ok => {},
        error => {
          this.showForUsers = !this.showForUsers
          this.isOrderAvailable = this.showForUsers;
        }
      );
    } else {
      this.restaurantService.HideMyRestaurantForUsers().subscribe(
        ok => {},
        error => {
          this.showForUsers = !this.showForUsers
          this.isOrderAvailable = this.showForUsers;
        }
      );
    }
  }

  isOrderAvailableStatusChanged() {
    if (this.isOrderAvailable) {
      this.restaurantService.TurnOnOrderOption().subscribe(
        ok => {},
        error => {
          this.isOrderAvailable = !this.isOrderAvailable;
        }
      );
    } else {
      this.restaurantService.TurnOffOrderOption().subscribe(
        ok => {},
        error => {
          this.isOrderAvailable = !this.isOrderAvailable;
        }
      );
    }
  }
}
