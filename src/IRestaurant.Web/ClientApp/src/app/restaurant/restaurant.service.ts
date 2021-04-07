import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EditRestaurant } from './models/edit-restaurant.type';
import { RestaurantDetails } from './models/restaurant-details.type';
import { RestaurantOverview } from './models/restaurant-overview.type';
import { RestaurantSettings } from './models/restaurant-settings.type';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  private baseUrl = environment.apiUrl + "restaurants/";
  restaurantRatingChanged = new Subject();

  constructor(private http: HttpClient) { }

  getRestaurantList(options?: {searchTerm?: string}) {
    let searchTerm = (options && options.searchTerm) || "";
    
    let params = new HttpParams();
    params = params.append("restaurantName", searchTerm);
    return this.http.get<RestaurantOverview[]>(this.baseUrl, {
      params: params
    });
  }

  getRestaurantDetails(restaurantId: number) {
    return this.http.get<RestaurantDetails>(this.baseUrl + restaurantId);
  }

  getMyRestaurantDetails() {
    return this.http.get<RestaurantDetails>(this.baseUrl + "myrestaurant");
  }

  editMyRestaurant(editedRestaurant: EditRestaurant) {
    return this.http.put<RestaurantDetails>(this.baseUrl + "myrestaurant", editedRestaurant);
  }

  getMyRestaurantSettings() {
    return this.http.get<RestaurantSettings>(this.baseUrl + "myrestaurant/settings");
  }

  showMyRestaurantForUsers() {
    return this.http.patch(this.baseUrl + "myrestaurant/show", null);
  }

  hideMyRestaurantForUsers() {
    return this.http.patch(this.baseUrl + "myrestaurant/hide", null);
  }

  turnOnOrderOption() {
    return this.http.patch(this.baseUrl + "myrestaurant/order/turnon", null);
  }

  turnOffOrderOption() {
    return this.http.patch(this.baseUrl + "myrestaurant/order/turnoff", null);
  }

  addRestaurantToFavourite(restaurantId: number) {
    return this.http.post(`${this.baseUrl}favourite/add/${restaurantId}`, null);
  }

  removeRestaurantFromFavourite(restaurantId: number) {
    return this.http.delete(`${this.baseUrl}favourite/remove/${restaurantId}`);
  }

  getGuestFavouriteRestaurantList(options?: {searchTerm?: string}) {
    let searchTerm = (options && options.searchTerm) || "";
    
    let params = new HttpParams();
    params = params.append("restaurantName", searchTerm);
    return this.http.get<RestaurantOverview[]>(this.baseUrl + "favourite", {
      params: params
    });
  }
}
