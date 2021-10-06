import { AuthConfig } from 'angular-oauth2-oidc';
import { environment } from 'src/environments/environment';

//Authentikációs beállítsok
export const authConfig: AuthConfig = {
  // Az SPA azonosítója. Az SPA ezzel az azonosítóval van beregisztrálva az auth serveren
  clientId: 'irestaurant_angular_spa',

  // Identity Provider URL
  issuer: environment.authServerUrl,
  requireHttps: true,

  // Az SPA URL-je, miután a felhasználó be- és kijelentkezett
  redirectUri: window.location.origin,
  postLogoutRedirectUri: window.location.origin,
  logoutUrl: window.location.origin,

  //Code flow authentikáció használata
  responseType: 'code',

  // A kliens scope-jának beállítása
  // Az első három az OIDC által definiált, az utolsó a REST API hozzáférés
  scope: 'openid profile email irestaurant.api',

  useSilentRefresh: true,
  skipIssuerCheck: true,
};
