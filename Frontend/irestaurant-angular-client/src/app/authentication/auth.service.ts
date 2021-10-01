import { Injectable } from '@angular/core';
import { OAuthErrorEvent, OAuthService } from 'angular-oauth2-oidc';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { authConfig } from './auth-config';
import { UserRole } from './user-roles';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  /**
   * Az aktuális felhasználó szerepköre (role).
   * Az access token tartalmazza ezt az információt, így ezt a token megfelelő részének dekódolásával nyerjük ki.
   * Ezután a dekódolt információt átalakítjuk enum értékké.
   */
  private currentUserRoleSubject = new BehaviorSubject<UserRole>(UserRole.NotAuthorized);
  public currentUserRole = this.currentUserRoleSubject.asObservable();

  constructor(private oauthService: OAuthService) {}

  public runInitialLoginSequence() {
    this.oauthService.events.subscribe(event => {
      if (event instanceof OAuthErrorEvent) {
        console.error('OAuthErrorEvent Object:', event);
      } else {
        console.warn('OAuthEvent Object:', event);
      }
    });

    this.oauthService.events.subscribe(_ => {
      if (this.oauthService.hasValidAccessToken()) {
        let token = this.oauthService.getAccessToken();
        let jwtData = token.split('.')[1];
        let decodedJwtJsonData = window.atob(jwtData);
        let decodedJwtData = JSON.parse(decodedJwtJsonData);

        this.currentUserRoleSubject.next(
          decodedJwtData.role === UserRole.Restaurant.toString() ? UserRole.Restaurant :
          decodedJwtData.role === UserRole.Guest.toString() ? UserRole.Guest : UserRole.NotAuthorized
        );
      } else {
        this.currentUserRoleSubject.next(UserRole.NotAuthorized);
      }
    });

    this.oauthService.configure(authConfig);
    this.oauthService.setupAutomaticSilentRefresh();
    return this.oauthService.loadDiscoveryDocumentAndTryLogin();
  }

  public login() { this.oauthService.initLoginFlow(); }
  public logout() { this.oauthService.logOut(); }
  public navigateToProfilePage() { 
    window.location.href = `${environment.authServerUrl}/Identity/Account/Manage`;
  }
  public refresh() { this.oauthService.silentRefresh(); }
  public hasValidToken() { return this.oauthService.hasValidAccessToken(); }

  public get accessToken() { return this.oauthService.getAccessToken(); }
  public get refreshToken() { return this.oauthService.getRefreshToken(); }
  public get identityClaims() { return this.oauthService.getIdentityClaims(); }
  public get idToken() { return this.oauthService.getIdToken(); }
  public get logoutUrl() { return this.oauthService.logoutUrl; }

  public tokenReceivedEvent() {
    return this.oauthService.events.pipe(filter((e) => e.type === 'token_received'));
  }
}

export function initializeAuthService(authService: AuthService) {
  return async () => {
      return authService.runInitialLoginSequence();
  };
}
