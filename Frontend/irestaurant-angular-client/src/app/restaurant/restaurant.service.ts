import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PagedList } from '../shared/models/pagedList.type';
import { EditRestaurant } from './models/edit-restaurant.type';
import { RestaurantDetails } from './models/restaurant-details.type';
import { RestaurantOverview } from './models/restaurant-overview.type';
import { RestaurantSearch } from './models/restaurant-search.type';
import { RestaurantSettings } from './models/restaurant-settings.type';
import { RestaurantSortBy } from './models/restaurant-sort-by.type';

@Injectable({
  providedIn: 'root',
})
export class RestaurantService {
  private restaurantApiUrl = environment.webApiUrl + '/api/restaurant';
  /** Jelzi, ha az étterem értékelése megváltozott. */
  restaurantRatingChanged = new Subject();

  constructor(private http: HttpClient) {}

  /**
   * Az átadott API URL-ről lekéri a megadott keresési feltételre illeszkedő éttermek áttekintő adatait.
   * @param apiUrl A API elérési útja.
   * @param search A keresési feltételeket tartalmazza.
   * @returns Az étteremek áttekintő adatait tartalamazó lista.
   */
  private getRestaurantListBase(apiUrl: string, search?: RestaurantSearch) {
    return this.http
      .get<PagedList<RestaurantOverview>>(apiUrl, {
        params: new HttpParams({ fromObject: search as any }),
      })
      .pipe(
        map((pagedList) => {
          pagedList.result.map((restaurant) => {
            if (restaurant?.imagePath?.startsWith('http')) {
              return restaurant;
            }
            restaurant.imagePath =
              restaurant.imagePath === null
                ? environment.defaultRestaurantImgUrl
                : `${environment.webApiUrl}/${restaurant.imagePath}`;
            return restaurant;
          });
          return pagedList;
        })
      );
  }

  /**
   * A megadott szűrési feltételre illeszkedő éttermek áttekintő adatainak lekérdezése.
   * @param search A keresési feltételeket tartalmazza.
   * @returns Az étteremek áttekintő adatait tartalamazó lista.
   */
  getRestaurantList(search?: RestaurantSearch) {
    return this.getRestaurantListBase(this.restaurantApiUrl, search);
  }

  /**
   * Az aktuális vendég kedvenc éttermeinek, azok áttekintő adatainak lekérdezése,
   * ami a szűrési feltételre illeszkedik.
   * @param search A keresési feltételeket tartalmazza.
   * @returns Az étteremek áttekintő adatait tartalamazó lista.
   */
  getGuestFavouriteRestaurantList(search?: RestaurantSearch) {
    return this.getRestaurantListBase(
      `${this.restaurantApiUrl}/favourite`,
      search
    );
  }

  /**
   * A megadott azonosítójú étterem részletes adatainak lekérése.
   * Ha az azonosító 'myrestaurant', akkor a felhasználó saját éttermét kéri le.
   * @param restaurantId Az étterem azonosítója.
   * @returns Az étterem részletes adatai.
   */
  private getRestaurantDetailsBase(restaurantId: string) {
    return this.http
      .get<RestaurantDetails>(`${this.restaurantApiUrl}/${restaurantId}`)
      .pipe(
        map((restaurantData) => {
          if (restaurantData?.imagePath?.startsWith('http')) {
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
    return this.getRestaurantDetailsBase(restaurantId.toString());
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

  /**
   * A megadott rendezéshez tartozó szöveg lekérdezése.
   * @param status A rendezés sorrendje.
   * @returns A rendezés sorrendjének szövege.
   */
  getRestaurantSortByInString(sortBy: RestaurantSortBy) {
    switch (sortBy) {
      case RestaurantSortBy.NAME_ASC:
        return 'Név ↑';
      case RestaurantSortBy.NAME_DESC:
        return 'Név ↓';
      case RestaurantSortBy.RATING_ASC:
        return 'Értékelés ↑';
      case RestaurantSortBy.RATING_DESC:
        return 'Értékelés ↓';
      case RestaurantSortBy.REVIEW_COUNT_ASC:
        return 'Értékelések száma ↑';
      case RestaurantSortBy.REVIEW_COUNT_DESC:
        return 'Értékelések száma ↓';
    }
  }
}
