import { Injectable } from '@angular/core';
import { OAuthErrorEvent, OAuthService } from 'angular-oauth2-oidc';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { authConfig } from './models/auth-config';
import { UserRole } from './models/user-roles';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private currentUserRoleSubject = new BehaviorSubject<UserRole>(
    UserRole.NotAuthorized
  );
  /**
   * Az aktuális felhasználó szerepköre (role).
   * Az access token tartalmazza ezt az információt, így ezt a token megfelelő részének dekódolásával nyerjük ki.
   * Ezután a dekódolt információt átalakítjuk enum értékké.
   */
  currentUserRole = this.currentUserRoleSubject.asObservable();

  constructor(private oauthService: OAuthService) {}

  /**
   * Az authentikációs szolgáltatás inicializálása.
   */
  runInitialLoginSequence() {
    this.oauthService.events.subscribe((_) => {
      if (this.oauthService.hasValidAccessToken()) {
        let token = this.oauthService.getAccessToken();
        let jwtData = token.split('.')[1];
        let decodedJwtJsonData = window.atob(jwtData);
        let decodedJwtData = JSON.parse(decodedJwtJsonData);

        this.currentUserRoleSubject.next(
          decodedJwtData.role === UserRole.Restaurant.toString()
            ? UserRole.Restaurant
            : decodedJwtData.role === UserRole.Guest.toString()
            ? UserRole.Guest
            : UserRole.NotAuthorized
        );
      } else {
        this.currentUserRoleSubject.next(UserRole.NotAuthorized);
      }
    });

    this.oauthService.configure(authConfig);
    this.oauthService.setupAutomaticSilentRefresh();
    return this.oauthService.loadDiscoveryDocumentAndTryLogin();
  }

  /**
   * Az alkalmazásba való bejelentkezés inicializálása.
   */
  login() {
    this.oauthService.initLoginFlow();
  }

  /**
   * Kijelentkezés az alkalmazásból.
   */
  logout() {
    this.oauthService.logOut();
  }

  /**
   * A felhasználó profil oldalára való navigálás.
   */
  navigateToProfilePage() {
    window.location.href = `${environment.authServerUrl}/Identity/Account/Manage`;
  }
}

/**
 * Az authentikációs szolgáltatás inicializálása az alkalmazás indulásakor.
 */
export function initializeAuthService(authService: AuthService) {
  return async () => {
    return authService.runInitialLoginSequence();
  };
}
