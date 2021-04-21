import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserAddressWithId } from '../shared/models/user-address-with-id.type';
import { UserAddress } from '../shared/models/user-address.type';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl = environment.apiUrl + "users/";

  constructor(private http: HttpClient) { }

  getCurrentGuestAddressList() {
    return this.http.get<UserAddressWithId[]>(this.baseUrl + "address");
  }

  createUserAddress(address: UserAddress) {
    return this.http.post<UserAddressWithId>(this.baseUrl + "address", address);
  }
}
