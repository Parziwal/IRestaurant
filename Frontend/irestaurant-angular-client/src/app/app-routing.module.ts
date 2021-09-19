import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthorizeGuard } from "./authentication/guards/authorize.guard";
import { GuestRoleGuard } from "./authentication/guards/guest-role.guard";
import { RestaurantRoleGuard } from "./authentication/guards/restaurant-role.guard";
import { UserRole } from "./authentication/user-roles";
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
    canActivate: [GuestRoleGuard],
    data: {
      restaurantListType: RestaurantListType.Favourite,
    },
  },
  {
    path: "restaurant/details/:id",
    component: RestaurantDetailsComponent
  },
  {
    path: "restaurant/details/:id/order",
    component: CreateOrderComponent,
    canActivate: [GuestRoleGuard],
    data: { role: UserRole.Guest },
  },
  {
    path: "myrestaurant",
    component: RestaurantDetailsComponent,
    canActivate: [RestaurantRoleGuard],
  },
  {
    path: "myrestaurant/edit",
    component: EditRestaurantComponent,
    canActivate: [RestaurantRoleGuard],
  },
  {
    path: "myrestaurant/settings",
    component: RestaurantSettingsComponent,
    canActivate: [RestaurantRoleGuard],
  },
  {
    path: "myrestaurant/menu",
    component: EditFoodListComponent,
    canActivate: [RestaurantRoleGuard],
  },
  {
    path: "myreviews",
    component: GuestReviewListComponent,
    canActivate: [GuestRoleGuard],
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
  exports: [RouterModule]
})
export class AppRoutingModule { }
