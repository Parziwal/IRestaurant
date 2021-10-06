import { OAuthModuleConfig } from 'angular-oauth2-oidc';
import { environment } from 'src/environments/environment';

//Az erőforrás/web api szerver beállítása automatikus token küldésel.
export const authModuleConfig: OAuthModuleConfig = {
  resourceServer: {
    allowedUrls: [environment.webApiUrl],
    sendAccessToken: true,
  },
};
