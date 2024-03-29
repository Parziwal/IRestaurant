import { CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
import { registerLocaleData } from '@angular/common';
import localeHu from '@angular/common/locales/hu';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './authentication/auth.module';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RestaurantListComponent } from './restaurant/restaurant-list/restaurant-list.component';
import { RestaurantListItemComponent } from './restaurant/restaurant-list/restaurant-list-item/restaurant-list-item.component';
import { RestaurantDetailsComponent } from './restaurant/restaurant-details/restaurant-details.component';
import { SpinnerComponent } from './shared/components/spinner/spinner.component';
import { RatingBarComponent } from './shared/components/rating-bar/rating-bar.component';
import { RestaurantMenuComponent } from './food/restaurant-menu/restaurant-menu.component';
import { EditRestaurantComponent } from './restaurant/edit-restaurant/edit-restaurant.component';
import { EditFoodDialogComponent } from './food/edit-food-list/edit-food-dialog/edit-food-dialog.component';
import { EditFoodListComponent } from './food/edit-food-list/edit-food-list.component';
import { RestaurantSettingsComponent } from './restaurant/restaurant-settings/restaurant-settings.component';
import {
  DropdownDirective,
  DropdownMenuDirective,
} from './shared/directives/dropdown.directive';
import { HttpErrorInterceptor } from './shared/interceptors/http-error.interceptor';
import { ConfirmationDialogComponent } from './shared/components/confirmation-dialog/confirmation-dialog.component';
import { RestaurantReviewListComponent } from './review/restaurant-review-list/restaurant-review-list.component';
import { RestaurantReviewListItemComponent } from './review/restaurant-review-list/restaurant-review-list-item/restaurant-review-list-item.component';
import { AddReviewDialogComponent } from './review/restaurant-review-list/add-review-dialog/add-review-dialog.component';
import { GuestReviewListComponent } from './review/guest-review-list/guest-review-list.component';
import { OrderListComponent } from './order/order-list/order-list.component';
import { OrderListItemComponent } from './order/order-list/order-tab/order-list-item/order-list-item.component';
import { OrderDetailsComponent } from './order/order-details/order-details.component';
import { ChangeOrderStatusDialogComponent } from './order/order-list/order-tab/order-list-item/change-order-status-dialog/change-order-status-dialog.component';
import { CreateOrderComponent } from './order/create-order/create-order.component';
import { ChooseFoodsComponent } from './order/create-order/choose-foods/choose-foods.component';
import { DeliveryDetailsComponent } from './order/create-order/delivery-details/delivery-details.component';
import { OrderFinalizationComponent } from './order/create-order/order-finalization/order-finalization.component';
import { ImagePickerComponent } from './shared/components/image-picker/image-picker.component';
import { UploadFoodImageDialogComponent } from './food/edit-food-list/upload-food-image-dialog/upload-food-image-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularMaterialModule } from './angular-material.module';
import { FooterComponent } from './footer/footer.component';
import { RestaurantSearchBarComponent } from './restaurant/restaurant-list/restaurant-search-bar/restaurant-search-bar.component';
import { OrderTabComponent } from './order/order-list/order-tab/order-tab.component';
import { OrderSearchBarComponent } from './order/order-list/order-search-bar/order-search-bar.component';
import { AboutUsComponent } from './about-us/about-us.component';

registerLocaleData(localeHu, 'hu');

@NgModule({
  declarations: [
    AppComponent,
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
    ConfirmationDialogComponent,
    RestaurantReviewListComponent,
    RestaurantReviewListItemComponent,
    AddReviewDialogComponent,
    GuestReviewListComponent,
    OrderListComponent,
    OrderListItemComponent,
    OrderDetailsComponent,
    ChangeOrderStatusDialogComponent,
    CreateOrderComponent,
    ChooseFoodsComponent,
    DeliveryDetailsComponent,
    OrderFinalizationComponent,
    ImagePickerComponent,
    UploadFoodImageDialogComponent,
    FooterComponent,
    RestaurantSearchBarComponent,
    OrderTabComponent,
    OrderSearchBarComponent,
    AboutUsComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AuthModule,
    AppRoutingModule,
    NgxSpinnerModule,
    ToastrModule.forRoot(),
    AngularMaterialModule,
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'hu' },
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
