import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Food } from './models/food.type';

@Injectable({
  providedIn: 'root'
})
export class FoodService {

  private baseUrl = environment.apiUrl + "foods/";

  constructor(private http: HttpClient) { }
  
  getRestaurantMenu(id: number) {
    return this.http.get<Food[]>(this.baseUrl + "restaurant/" + id);
  }
}
