import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateFood } from './models/create-food.type';
import { EditFood } from './models/edit-food.type';
import { Food } from './models/food.type';

@Injectable({
  providedIn: 'root'
})
export class FoodService {

  private baseUrl = environment.apiUrl + "foods/";

  constructor(private http: HttpClient) { }
  
  getFood(foodId: number) {
    return this.http.get<Food>(this.baseUrl + foodId);
  }

  getRestaurantMenu(restaurntId: number) {
    return this.http.get<Food[]>(this.baseUrl + "restaurant/" + restaurntId);
  }

  getMyRestaurantMenu() {
    return this.http.get<Food[]>(this.baseUrl + "restaurant/myrestaurant");
  }

  addFoodToRestaurantMenu(createdFood: CreateFood) {
    return this.http.post<Food>(this.baseUrl, createdFood);
  }

  editFood(foodId: number, editedFood: EditFood) {
    return this.http.put<Food>(this.baseUrl + foodId, editedFood);
  }

  removeFoodFromMenu(id: number) {
    return this.http.delete(this.baseUrl + id);
  }
}
