import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { LoginComponent } from './login/login.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';



@NgModule({
  declarations: [
    LoginComponent,
    AuthCallbackComponent
  ],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    NgxSpinnerModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AuthenticationModule { }
