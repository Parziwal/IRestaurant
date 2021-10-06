import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserAddressWithId } from '../shared/models/user-address-with-id.type';
import { UserAddress } from '../shared/models/user-address.type';

@Injectable({
  providedIn: 'root',
})
export class GuestAddressService {
  private userAddressApiUrl = environment.webApiUrl + '/api/guestaddress/';

  constructor(private http: HttpClient) {}

  /**
   * Az aktuális vendéghez tartozó lakcímek lekérdezése.
   * @returns Az aktuális vendég lakcími.
   */
  getCurrentGuestAddressList() {
    return this.http.get<UserAddressWithId[]>(this.userAddressApiUrl);
  }

  /**
   * Lakcím létrehozása az aktuális felhasználóhoz.
   * @param address A lakcím adatai.
   * @returns A létrehozott lakcím.
   */
  createUserAddress(address: UserAddress) {
    return this.http.post<UserAddressWithId>(this.userAddressApiUrl, address);
  }
}
