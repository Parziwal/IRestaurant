import { Component, NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { UserRole } from "src/api-authorization/api-authorization.constants";
import { AuthorizeGuard } from "src/api-authorization/authorize.guard";
import { RoleGuard } from "src/api-authorization/role.guard";
import { EditFoodListComponent } from "./food/edit-food-list/edit-food-list.component";
import { CreateOrderComponent } from "./order/create-order/create-order.component";
import { OrderDetailsComponent } from "./order/order-details/order-details.component";
import { OrderListComponent } from "./order/order-list/order-list.component";
import { EditRestaurantComponent } from "./restaurant/edit-restaurant/edit-restaurant.component";
import { RestaurantListType } from "./restaurant/models/restaurant-list-type.type";
import { RestaurantDetailsComponent } from "./restaurant/restaurant-details/restaurant-details.component";
import { RestaurantListComponent } from "./restaurant/restaurant-list/restaurant-list.component";
import { RestaurantSettingsComponent } from "./restaurant/restaurant-settings/restaurant-settings.component";
import { GuestReviewListComponent } from "./review/guest-review-list/guest-review-list.component";

const routes: Routes = [
  {
    path: "restaurant",
    component: RestaurantListComponent,
    data: { restaurantListType: RestaurantListType.All },
  },
  {
    path: "restaurant/favourite",
    component: RestaurantListComponent,
    canActivate: [RoleGuard],
    data: {
      role: UserRole.Guest,
      restaurantListType: RestaurantListType.Favourite,
    },
  },
  {
    path: "restaurant/details/:id",
    component: RestaurantDetailsComponent
  },
  {
    path: "restaurant/details/:id/order",
    component: CreateOrderComponent
  },
  {
    path: "myrestaurant",
    component: RestaurantDetailsComponent,
    canActivate: [RoleGuard],
    data: { role: UserRole.Restaurant },
  },
  {
    path: "myrestaurant/edit",
    component: EditRestaurantComponent,
    canActivate: [RoleGuard],
    data: { role: UserRole.Restaurant },
  },
  {
    path: "myrestaurant/settings",
    component: RestaurantSettingsComponent,
    canActivate: [RoleGuard],
    data: { role: UserRole.Restaurant },
  },
  {
    path: "myrestaurant/menu",
    component: EditFoodListComponent,
    canActivate: [RoleGuard],
    data: { role: UserRole.Restaurant },
  },
  {
    path: "myreviews",
    component: GuestReviewListComponent,
    canActivate: [RoleGuard],
    data: { role: UserRole.Guest },
  },
  {
    path: "order",
    component: OrderListComponent,
    canActivate: [AuthorizeGuard]
  },
  {
    path: "order/details/:id",
    component: OrderDetailsComponent
  },
  { path: "**", redirectTo: "restaurant" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
