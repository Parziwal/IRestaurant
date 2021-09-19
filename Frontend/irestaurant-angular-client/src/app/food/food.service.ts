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

  private foodAPIURL = environment.webAPIURL + "/food";

  constructor(private http: HttpClient) { }
  
  /**
   * A megadott azonosítójú étel lekérése.
   * @param foodId Az étel azonosítója.
   * @returns Az étel adatai.
   */
  getFood(foodId: number) {
    return this.http.get<Food>(`${this.foodAPIURL}/${foodId}`);
  }

  /**
   * A megadott azonosítójú étteremhez tartozó ételek lekérdezése.
   * @param restaurntId Az étterem azonosítója.
   * @returns Az étterem ételeinek listája.
   */
  getRestaurantMenu(restaurntId: number) {
    return this.http.get<Food[]>(`${this.foodAPIURL}/restaurant/${restaurntId}`);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem étlapjának lekérdezése.
   * @returns A felhasználó étterméhez tartozó ételek.
   */
  getMyRestaurantMenu() {
    return this.http.get<Food[]>(`${this.foodAPIURL}/restaurant/myrestaurant`);
  }

  /**
   * Étel hozzáadása az aktuális felhasználóhoz tartozó étteremhez.
   *  @returns A létrehozott étel adatai.
   */
  addFoodToRestaurantMenu(createdFood: CreateFood) {
    return this.http.post<Food>(this.foodAPIURL, createdFood);
  }

  /**
   * Kép feltöltése a megadott azonosítójú ételhez.
   * @param foodId Az étel azonosítója.
   * @param image A feltöltendő kép-
   * @returns A feltöltött kép relatív elérési útja.
   */
  uploadFoodImage(foodId: number, image: File) {
    const imageFormData = new FormData();
    imageFormData.append('imageFile', image);
    return this.http.post<{relativeImagePath: string}>(`${this.foodAPIURL}/${foodId}/image`, imageFormData);
  }

  /**
   * A megadott azonosítójú étel képének törlése.
   * @param foodId Az étel azonosítója.
   */
  deleteFoodImage(foodId: number) {
    return this.http.delete(`${this.foodAPIURL}/${foodId}/image`);
  }

  /**
   * A megadott azonosítójú étel adatainak módosítása.
   * @param foodId Az étel azonosítója.
   * @param editedFood Az étel módosítandó adatai.
   * @returns Az étel módosított adatai.
   */
  editFood(foodId: number, editedFood: EditFood) {
    return this.http.put<Food>(`${this.foodAPIURL}/${foodId}`, editedFood);
  }

  /**
   * A megadott azonosítójú étel törlése a felhasználóhoz tartozó étterem étlapjáról.
   * @param foodId Az étel azonosítója.
   */
  removeFoodFromMenu(foodId: number) {
    return this.http.delete(`${this.foodAPIURL}/${foodId}`);
  }
}
