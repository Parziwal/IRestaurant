import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User, UserManager, UserManagerSettings } from 'oidc-client';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private manager = new UserManager(getClientSettings());
  private user: User | null = null;
  private authApiURL = environment.authServerURL;
  private authNavStatusSource = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) {   
    this.manager.getUser().then(user => { 
      this.user = user;      
      this.authNavStatusSource.next(this.isAuthenticated());
    });
  }

  login() { 
    return this.manager.signinRedirect();
  }

  async completeAuthentication() {
    this.user = await this.manager.signinRedirectCallback();
    this.authNavStatusSource.next(this.isAuthenticated());      
  }

  register(userRegistration: any) {    
    return this.http.post(this.authApiURL + '/account', userRegistration);
  }

  isAuthenticated(): boolean {
    return this.user != null && !this.user.expired;
  }

  get authorizationHeaderValue(): string {
    if (this.user == null) {
      return "";
    }
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  get name(): string {
    return this.user != null ? this.user.profile.name! : '';
  }

  async signout() {
    await this.manager.signoutRedirect();
  }

  get getClientSettings(): UserManagerSettings {
    return {
      authority: this.authApiURL,
      client_id: 'irestaurant_angular_spa',
      redirect_uri: 'http://localhost:4200/auth-callback',
      post_logout_redirect_uri: 'http://localhost:4200/',
      response_type:"id_token token",
      scope:"openid profile email irestaurant.api",
      filterProtocolClaims: true,
      loadUserInfo: true,
      automaticSilentRenew: true,
      silent_redirect_uri: 'http://localhost:4200/silent-refresh.html'
    }
  }
}

export function getClientSettings(): UserManagerSettings {
  return {
      authority: 'https://localhost:5000',
      client_id: 'irestaurant_angular_spa',
      redirect_uri: 'http://localhost:4200/auth-callback',
      post_logout_redirect_uri: 'http://localhost:4200/',
      response_type:"code",
      scope:"openid profile email irestaurant.api",
      filterProtocolClaims: true,
      loadUserInfo: true,
      automaticSilentRenew: true,
      silent_redirect_uri: 'http://localhost:4200/silent-refresh.html' 
  };
}