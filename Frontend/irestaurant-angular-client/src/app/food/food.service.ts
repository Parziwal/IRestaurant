import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { CreateFood } from './models/create-food.type';
import { EditFood } from './models/edit-food.type';
import { Food } from './models/food.type';

@Injectable({
  providedIn: 'root',
})
export class FoodService {
  private foodApiUrl = environment.webApiUrl + '/api/food';

  constructor(private http: HttpClient) {}

  /**
   * A megadott azonosítójú étel lekérése.
   * @param foodId Az étel azonosítója.
   * @returns Az étel adatai.
   */
  getFood(foodId: number) {
    return this.http.get<Food>(`${this.foodApiUrl}/${foodId}`).pipe(
      map((foodData) => {
        if (foodData?.imagePath?.startsWith('http')) {
          return foodData;
        }
        foodData.imagePath =
          foodData.imagePath === null
            ? environment.defaultFoodImgUrl
            : `${environment.webApiUrl}/${foodData.imagePath}`;
        return foodData;
      })
    );
  }

  /**
   * A megadott azonosítójú étteremhez tartozó ételek lekérdezése.
   * Ha az azonosító 'myrestaurant', akkor a felhasználó saját éttermének ételeit kéri le.
   * @param restaurntId Az étterem azonosítója.
   * @returns Az étterem ételeinek listája.
   */
  private getRestaurantMenuBase(restaurntId: number | string) {
    return this.http
      .get<Food[]>(`${this.foodApiUrl}/restaurant/${restaurntId}`)
      .pipe(
        map((foodList) => {
          return foodList.map((food) => {
            if (food?.imagePath?.startsWith('http')) {
              return food;
            }
            food.imagePath =
              food.imagePath === null
                ? environment.defaultFoodImgUrl
                : `${environment.webApiUrl}/${food.imagePath}`;
            return food;
          });
        })
      );
  }

  /**
   * A megadott azonosítójú étteremhez tartozó ételek lekérdezése.
   * @param restaurntId Az étterem azonosítója.
   * @returns Az étterem ételeinek listája.
   */
  getRestaurantMenu(restaurntId: number) {
    return this.getRestaurantMenuBase(restaurntId);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem étlapjának lekérdezése.
   * @returns A felhasználó étterméhez tartozó ételek.
   */
  getMyRestaurantMenu() {
    return this.getRestaurantMenuBase('myrestaurant');
  }

  /**
   * Étel hozzáadása az aktuális felhasználóhoz tartozó étteremhez.
   *  @returns A létrehozott étel adatai.
   */
  addFoodToRestaurantMenu(createdFood: CreateFood) {
    return this.http.post<Food>(this.foodApiUrl, createdFood);
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
    return this.http
      .post<{ relativeImagePath: string }>(
        `${this.foodApiUrl}/${foodId}/image`,
        imageFormData
      )
      .pipe(
        map((image) => {
          if (image.relativeImagePath.startsWith('http')) {
            return image;
          }
          image.relativeImagePath =
            image.relativeImagePath === null
              ? environment.defaultRestaurantImgUrl
              : `${environment.webApiUrl}/${image.relativeImagePath}`;
          return image;
        })
      );
  }

  /**
   * A megadott azonosítójú étel képének törlése.
   * @param foodId Az étel azonosítója.
   */
  deleteFoodImage(foodId: number) {
    return this.http.delete(`${this.foodApiUrl}/${foodId}/image`);
  }

  /**
   * A megadott azonosítójú étel adatainak módosítása.
   * @param foodId Az étel azonosítója.
   * @param editedFood Az étel módosítandó adatai.
   * @returns Az étel módosított adatai.
   */
  editFood(foodId: number, editedFood: EditFood) {
    return this.http.put<Food>(`${this.foodApiUrl}/${foodId}`, editedFood);
  }

  /**
   * A megadott azonosítójú étel törlése a felhasználóhoz tartozó étterem étlapjáról.
   * @param foodId Az étel azonosítója.
   */
  removeFoodFromMenu(foodId: number) {
    return this.http.delete(`${this.foodApiUrl}/${foodId}`);
  }
}
