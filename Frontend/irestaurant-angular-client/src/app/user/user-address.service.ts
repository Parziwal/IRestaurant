import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserAddressWithId } from '../shared/models/user-address-with-id.type';
import { UserAddress } from '../shared/models/user-address.type';

@Injectable({
  providedIn: 'root'
})
export class UserAddressService {

  private userAddressAPIURL = environment.webAPIURL + "/useraddress/";

  constructor(private http: HttpClient) { }

  /**
   * Az aktuális vendéghez tartozó lakcímek lekérdezése.
   * @returns Az aktuális vendég lakcími.
   */
  getCurrentGuestAddressList() {
    return this.http.get<UserAddressWithId[]>(this.userAddressAPIURL);
  }

  /**
   * Lakcím létrehozása az aktuális felhasználóhoz.
   * @param address A lakcím adatai.
   * @returns A létrehozott lakcím.
   */
  createUserAddress(address: UserAddress) {
    return this.http.post<UserAddressWithId>(this.userAddressAPIURL, address);
  }
}
