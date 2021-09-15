import { APP_INITIALIZER, NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OAuthModule, OAuthService } from 'angular-oauth2-oidc';
import { configureAuth } from './auth-config';
import { authModuleConfig } from './auth-module-config';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    OAuthModule.forRoot(
      authModuleConfig
    ),
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: configureAuth,
      deps: [OAuthService],
      multi: true,
    },
  ]
})

export class AuthModule {
  constructor(@Optional() @SkipSelf() parentModule: AuthModule) {
    if (parentModule) {
      throw new Error('CoreModule is already loaded. Import it in the AppModule only');
    }
  }
}
