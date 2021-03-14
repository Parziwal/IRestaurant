import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { EditRestaurantComponent } from './restaurant/edit-restaurant/edit-restaurant.component';
import { RestaurantDetailsComponent } from './restaurant/restaurant-details/restaurant-details.component';
import { RestaurantListComponent } from './restaurant/restaurant-list/restaurant-list.component';

const routes: Routes = [
  {path: 'restaurant', component: RestaurantListComponent },
  {path: 'restaurant/details/:id', component: RestaurantDetailsComponent },
  {path: 'myrestaurant', component: EditRestaurantComponent },
  {path: '**', redirectTo: 'restaurant'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
