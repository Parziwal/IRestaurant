import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { AppRoutingModule } from './app-routing.module';
import { RestaurantListComponent } from './restaurant/restaurant-list/restaurant-list.component';
import { RestaurantListItemComponent } from './restaurant/restaurant-list/restaurant-list-item/restaurant-list-item.component';
import { RestaurantDetailsComponent } from './restaurant/restaurant-details/restaurant-details.component';
import { SpinnerComponent } from './shared/components/spinner/spinner.component';
import { RatingBarComponent } from './shared/components/rating-bar/rating-bar.component';
import { RestaurantMenuComponent } from './food/restaurant-menu/restaurant-menu.component';
import { EditRestaurantComponent } from './restaurant/edit-restaurant/edit-restaurant.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material.module';
import { ToastrModule } from 'ngx-toastr';
import { EditMenuComponent } from './food/edit-menu/edit-menu.component';
import { FoodListComponent } from './food/edit-menu/food-list/food-list.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RestaurantSettingsComponent } from './restaurant/restaurant-settings/restaurant-settings.component';
import { DropdownDirective, DropdownMenuDirective } from './shared/directives/dropdown.directive';
import { HttpErrorInterceptor } from './shared/interceptors/http-error.interceptor';

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
    EditMenuComponent,
    FoodListComponent,
    RestaurantSettingsComponent,
    DropdownDirective,
    DropdownMenuDirective
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
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
