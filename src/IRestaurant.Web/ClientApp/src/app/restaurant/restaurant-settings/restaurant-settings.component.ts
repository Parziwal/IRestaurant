import { Component, OnInit } from '@angular/core';
import { RestaurantSettings } from '../models/restaurant-settings.type';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-restaurant-settings',
  templateUrl: './restaurant-settings.component.html',
  styleUrls: ['./restaurant-settings.component.css']
})
export class RestaurantSettingsComponent implements OnInit {
  showForUsers = false;
  isOrderAvailable = false;

  constructor(private restaurantService: RestaurantService) { }

  ngOnInit(): void {
    this.loadRestaurantSettings();
  }

  loadRestaurantSettings() {
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
      this.restaurantService.ShowMyRestaurantForUsers().subscribe();
    } else {
      this.restaurantService.HideMyRestaurantForUsers().subscribe();
    }
  }

  isOrderAvailableStatusChanged() {
    if (this.isOrderAvailable) {
      this.restaurantService.TurnOnOrderOption().subscribe();
    } else {
      this.restaurantService.TurnOffOrderOption().subscribe();
    }
  }
}
