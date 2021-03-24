import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ToastrModule } from 'ngx-toastr';
import { AngularMaterialModule } from './angular-material.module';
import { AppRoutingModule } from './app-routing.module';
import { registerLocaleData } from '@angular/common';
import localeFr from '@angular/common/locales/hu';
registerLocaleData(localeFr, 'hu');

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { RestaurantListComponent } from './restaurant/restaurant-list/restaurant-list.component';
import { RestaurantListItemComponent } from './restaurant/restaurant-list/restaurant-list-item/restaurant-list-item.component';
import { RestaurantDetailsComponent } from './restaurant/restaurant-details/restaurant-details.component';
import { SpinnerComponent } from './shared/components/spinner/spinner.component';
import { RatingBarComponent } from './shared/components/rating-bar/rating-bar.component';
import { RestaurantMenuComponent } from './food/restaurant-menu/restaurant-menu.component';
import { EditRestaurantComponent } from './restaurant/edit-restaurant/edit-restaurant.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EditFoodDialogComponent } from './food/edit-food-list/edit-food-dialog/edit-food-dialog.component';
import { EditFoodListComponent } from './food/edit-food-list/edit-food-list.component';
import { RestaurantSettingsComponent } from './restaurant/restaurant-settings/restaurant-settings.component';
import { DropdownDirective, DropdownMenuDirective } from './shared/directives/dropdown.directive';
import { HttpErrorInterceptor } from './shared/interceptors/http-error.interceptor';
import { ConfirmationDialogComponent } from './shared/components/confirmation-dialog/confirmation-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    RestaurantListComponent,
    RestaurantListItemComponent,
    RestaurantDetailsComponent,
    SpinnerComponent,
    RatingBarComponent,
    RestaurantMenuComponent,
    EditRestaurantComponent,
    EditFoodDialogComponent,
    EditFoodListComponent,
    RestaurantSettingsComponent,
    DropdownDirective,
    DropdownMenuDirective,
    ConfirmationDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ApiAuthorizationModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    ToastrModule.forRoot(),
    FontAwesomeModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },
    { provide: LOCALE_ID, useValue: 'hu' },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
