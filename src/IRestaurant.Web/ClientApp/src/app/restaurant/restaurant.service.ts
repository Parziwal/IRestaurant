import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
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

  getMyRestaurant() {
    return this.http.get(this.baseUrl + "myrestaurant");
  }
}
