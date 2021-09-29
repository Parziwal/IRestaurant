import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { EditRestaurant } from './models/edit-restaurant.type';
import { RestaurantDetails } from './models/restaurant-details.type';
import { RestaurantOverview } from './models/restaurant-overview.type';
import { RestaurantSettings } from './models/restaurant-settings.type';

@Injectable({
  providedIn: 'root',
})
export class RestaurantService {
  private restaurantApiUrl = environment.webApiUrl + '/api/restaurant';
  /** Jelzi, ha az étterem értékelése megváltozott. */
  restaurantRatingChanged = new Subject();

  constructor(private http: HttpClient) {}

  /**
   * Az átadott API URL-ről lekéri a megadott szűrési feltételre illeszkedő éttermek áttekintő adatait.
   * @param apiUrl A API elérési útja.
   * @param options A szűrési feltételeket tartalmazza.
   * @returns Az étteremek áttekintő adatait tartalamazó lista.
   */
  private getRestaurantListBase(
    apiUrl: string,
    options?: { searchTerm?: string }
  ) {
    let searchTerm = (options && options.searchTerm) || '';

    let params = new HttpParams();
    params = params.append('restaurantName', searchTerm);
    return this.http
      .get<RestaurantOverview[]>(apiUrl, {
        params: params,
      })
      .pipe(
        map(RestaurantOverviewList => {
          return RestaurantOverviewList.map(restaurant => {
            if (restaurant.imagePath.startsWith('http')) {
              return restaurant;
            }
            restaurant.imagePath =
              restaurant.imagePath === null
                ? environment.defaultRestaurantImgUrl
                : `${environment.webApiUrl}/${restaurant.imagePath}`;
            return restaurant;
          });
        })
      );
  }

  /**
   * A megadott szűrési feltételre illeszkedő éttermek áttekintő adatainak lekérdezése.
   * @param options A szűrési feltételeket tartalmazza.
   * @returns Az étteremek áttekintő adatait tartalamazó lista.
   */
  getRestaurantList(options?: { searchTerm?: string }) {
    return this.getRestaurantListBase(this.restaurantApiUrl, options);
  }

  /**
   * Az aktuális vendég kedvenc éttermeinek, azok áttekintő adatainak lekérdezése,
   * ami a szűrési feltételre illeszkedik.
   * @param options A szűrési feltételeket tartalmazza.
   * @returns Az étteremek áttekintő adatait tartalamazó lista.
   */
  getGuestFavouriteRestaurantList(options?: { searchTerm?: string }) {
    return this.getRestaurantListBase(
      `${this.restaurantApiUrl}/favourite`,
      options
    );
  }

  /**
   * A megadott azonosítójú étterem részletes adatainak lekérése.
   * Ha az azonosító 'myrestaurant', akkor a felhasználó saját éttermét kéri le.
   * @param restaurantId Az étterem azonosítója.
   * @returns Az étterem részletes adatai.
   */
  private getRestaurantDetailsBase(restaurantId: number | string) {
    return this.http
      .get<RestaurantDetails>(`${this.restaurantApiUrl}/${restaurantId}`)
      .pipe(
        map(restaurantData => {
          if (restaurantData.imagePath.startsWith('http')) {
            return restaurantData;
          }
          restaurantData.imagePath =
            restaurantData.imagePath === null
              ? environment.defaultRestaurantImgUrl
              : `${environment.webApiUrl}/${restaurantData.imagePath}`;
          return restaurantData;
        })
      );
  }

  /**
   * A megadott azonosítójú étterem részletes adatainak lekérése.
   * @param restaurantId Az étterem azonosítója.
   * @returns Az étterem részletes adatai.
   */
  getRestaurantDetails(restaurantId: number) {
    return this.getRestaurantDetailsBase(restaurantId);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem részletes adatainak lekérdezése.
   * @returns Az aktuális felhasználóhoz tartozó étterem részletes adatai.
   */
  getMyRestaurantDetails() {
    return this.getRestaurantDetailsBase('myrestaurant');
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem adatainak szerkesztése.
   * @param editedRestaurant Az étterem módosítandó adatai.
   * @returns A módosított étterem részletes adatai.
   */
  editMyRestaurant(editedRestaurant: EditRestaurant) {
    return this.http.put<RestaurantDetails>(
      `${this.restaurantApiUrl}/myrestaurant`,
      editedRestaurant
    );
  }

  /**
   * Kép feltöltése az aktuális felhasználóhoz tartozó étteremhez.
   * @param image A feltöltendő kép.
   * @returns A kép relatív elérési útvonala.
   */
  uploadImageMyRestaurant(image: File) {
    const imageFormData = new FormData();
    imageFormData.append('imageFile', image);
    return this.http
      .post<{ relativeImagePath: string }>(
        `${this.restaurantApiUrl}/myrestaurant/image`,
        imageFormData
      )
      .pipe(
        map(image => {
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
   * Az aktuális felhasználóhoz tartozó étterem profil képének törlése.
   */
  deleteMyRestaurantImage() {
    return this.http.delete(`${this.restaurantApiUrl}/myrestaurant/image`);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem beállításainak lekérdezése.
   * @returns Az étterem beállításai.
   */
  getMyRestaurantSettings() {
    return this.http.get<RestaurantSettings>(
      `${this.restaurantApiUrl}/myrestaurant/settings`
    );
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem elérhetővé tétele a felhasználók számára.
   */
  showMyRestaurantForUsers() {
    return this.http.patch(`${this.restaurantApiUrl}/myrestaurant/show`, null);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem elrejtése a felhasználók elől.
   */
  hideMyRestaurantForUsers() {
    return this.http.patch(`${this.restaurantApiUrl}/myrestaurant/hide`, null);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem rendelési lehetőségének bekapcsolása.
   */
  turnOnOrderOption() {
    return this.http.patch(
      `${this.restaurantApiUrl}/myrestaurant/order/turnon`,
      null
    );
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem rendelési lehetőségének kikapcsolása.
   */
  turnOffOrderOption() {
    return this.http.patch(
      `${this.restaurantApiUrl}/myrestaurant/order/turnoff`,
      null
    );
  }

  /**
   * A megadott azonosítójú étterem felvétele az aktuákis vendég kedvencei közé.
   * @param restaurantId Az étterem azonosítója.
   */
  addRestaurantToFavourite(restaurantId: number) {
    return this.http.post(
      `${this.restaurantApiUrl}/favourite/add/${restaurantId}`,
      null
    );
  }

  /**
   * A megadott azonosítójú étterem törlése az aktuális vendég kedvencei közül.
   * @param restaurantId Az étterem azonosítója.
   */
  removeRestaurantFromFavourite(restaurantId: number) {
    return this.http.delete(
      `${this.restaurantApiUrl}/favourite/remove/${restaurantId}`
    );
  }
}
