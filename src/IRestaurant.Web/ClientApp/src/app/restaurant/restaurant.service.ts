import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { EditRestaurant } from './models/edit-restaurant.type';
import { RestaurantDetails } from './models/restaurant-details.type';
import { RestaurantOverview } from './models/restaurant-overview.type';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  private baseUrl = environment.apiUrl + "restaurants/";

  constructor(private http: HttpClient) { }

  getRestaurantOverviews(options?: {searchTerm?: string}) {
    let searchTerm = (options && options.searchTerm) || "";
    
    let params = new HttpParams();
    params = params.append("restaurantName", searchTerm);

    return this.http.get<RestaurantOverview[]>(this.baseUrl, {
      params: params
    });
  }

  getRestaurantDetails(id: number) {
    return this.http.get<RestaurantDetails>(this.baseUrl + id);
  }

  getMyRestaurant() {
    return this.http.get<RestaurantDetails>(this.baseUrl + "myrestaurant");
  }

  editMyRestaurant(editedRestaurant: EditRestaurant) {
    return this.http.put<RestaurantDetails>(this.baseUrl + "myrestaurant", editedRestaurant);
  }
}
