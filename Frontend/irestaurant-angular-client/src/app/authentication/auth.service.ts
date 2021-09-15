import { Injectable } from '@angular/core';
import { OAuthErrorEvent, OAuthService } from 'angular-oauth2-oidc';
import { BehaviorSubject } from 'rxjs';
import { filter } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(private oauthService: OAuthService) {
    this.oauthService.events.subscribe(event => {
      if (event instanceof OAuthErrorEvent) {
        console.error('OAuthErrorEvent Object:', event);
      } else {
        console.warn('OAuthEvent Object:', event);
      }
    });

    this.oauthService.events.subscribe(_ => {
        this.isAuthenticatedSubject.next(this.oauthService.hasValidAccessToken());
      });
  }

  public login() { this.oauthService.initLoginFlow(); }
  public logout() { this.oauthService.logOut(); }
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
