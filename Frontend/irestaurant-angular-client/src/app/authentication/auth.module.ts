import { APP_INITIALIZER, NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OAuthModule } from 'angular-oauth2-oidc';
import { authModuleConfig } from './models/auth-module-config';
import { AuthService, initializeAuthService } from './auth.service';

@NgModule({
  declarations: [],
  imports: [CommonModule, OAuthModule.forRoot(authModuleConfig)],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initializeAuthService,
      deps: [AuthService],
      multi: true,
    },
  ],
})
export class AuthModule {
  constructor(@Optional() @SkipSelf() parentModule: AuthModule) {
    if (parentModule) {
      throw new Error(
        'AuthModule is already loaded. Import it in the AppModule only'
      );
    }
  }
}
