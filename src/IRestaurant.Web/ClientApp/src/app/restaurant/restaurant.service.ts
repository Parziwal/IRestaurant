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

  private baseUrl = environment.apiUrl + "restaurant/";
  /** Jelzi, ha az étterem értékelése megváltozott. */
  restaurantRatingChanged = new Subject();

  constructor(private http: HttpClient) { }

  /**
   * A megadott szűrési feltételre illeszkedő éttermek áttekintő adatainak lekérdezése.
   * @param options A szűrési feltételeket tartalmazza.
   * @returns Az étteremek áttekintő adatait tartalamazó lista.
   */
  getRestaurantList(options?: {searchTerm?: string}) {
    let searchTerm = (options && options.searchTerm) || "";
    
    let params = new HttpParams();
    params = params.append("restaurantName", searchTerm);
    return this.http.get<RestaurantOverview[]>(this.baseUrl, {
      params: params
    });
  }

  /**
   * A megadott azonosítójú étterem részletes adatainak lekérése.
   * @param restaurantId Az étterem azonosítója.
   * @returns Az étterem részletes adatai.
   */
  getRestaurantDetails(restaurantId: number) {
    return this.http.get<RestaurantDetails>(`${this.baseUrl}${restaurantId}`);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem részletes adatainak lekérdezése.
   * @returns Az aktuális felhasználóhoz tartozó étterem részletes adatai.
   */
  getMyRestaurantDetails() {
    return this.http.get<RestaurantDetails>(`${this.baseUrl}myrestaurant`);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem adatainak szerkesztése.
   * @param editedRestaurant Az étterem módosítandó adatai.
   * @returns A módosított étterem részletes adatai.
   */
  editMyRestaurant(editedRestaurant: EditRestaurant) {
    return this.http.put<RestaurantDetails>(`${this.baseUrl}myrestaurant`, editedRestaurant);
  }

  /**
   * Kép feltöltése az aktuális felhasználóhoz tartozó étteremhez.
   * @param image A feltöltendő kép.
   * @returns A kép relatív elérési útvonala.
   */
  uploadImageMyRestaurant(image: File) {
    const imageFormData = new FormData();
    imageFormData.append('imageFile', image);
    return this.http.post<{relativeImagePath: string}>(`${this.baseUrl}myrestaurant/image`, imageFormData);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem profil képének törlése.
   */
  deleteMyRestaurantImage() {
    return this.http.delete(`${this.baseUrl}myrestaurant/image`);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem beállításainak lekérdezése.
   * @returns Az étterem beállításai.
   */
  getMyRestaurantSettings() {
    return this.http.get<RestaurantSettings>(`${this.baseUrl}myrestaurant/settings`);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem elérhetővé tétele a felhasználók számára.
   */
  showMyRestaurantForUsers() {
    return this.http.patch(`${this.baseUrl}myrestaurant/show`, null);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem elrejtése a felhasználók elől.
   */
  hideMyRestaurantForUsers() {
    return this.http.patch(`${this.baseUrl}myrestaurant/hide`, null);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem rendelési lehetőségének bekapcsolása.
   */
  turnOnOrderOption() {
    return this.http.patch(`${this.baseUrl}myrestaurant/order/turnon`, null);
  }

  /**
   * Az aktuális felhasználóhoz tartozó étterem rendelési lehetőségének kikapcsolása.
   */
  turnOffOrderOption() {
    return this.http.patch(`${this.baseUrl}myrestaurant/order/turnoff`, null);
  }

  /**
   * A megadott azonosítójú étterem felvétele az aktuákis vendég kedvencei közé.
   * @param restaurantId Az étterem azonosítója.
   */
  addRestaurantToFavourite(restaurantId: number) {
    return this.http.post(`${this.baseUrl}favourite/add/${restaurantId}`, null);
  }

  /**
   * A megadott azonosítójú étterem törlése az aktuális vendég kedvencei közül.
   * @param restaurantId Az étterem azonosítója.
   */
  removeRestaurantFromFavourite(restaurantId: number) {
    return this.http.delete(`${this.baseUrl}favourite/remove/${restaurantId}`);
  }

  /**
   * Az aktuális vendég kedvenc éttermeinek, azok áttekintő adatainak lekérdezése, 
   * ami a szűrési feltételre illeszkedik.
   * @param options A szűrési feltételeket tartalmazza.
   * @returns Az étteremek áttekintő adatait tartalamazó lista.
   */
  getGuestFavouriteRestaurantList(options?: {searchTerm?: string}) {
    let searchTerm = (options && options.searchTerm) || "";
    
    let params = new HttpParams();
    params = params.append("restaurantName", searchTerm);
    return this.http.get<RestaurantOverview[]>(`${this.baseUrl}favourite`, {
      params: params
    });
  }
}
