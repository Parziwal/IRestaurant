import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { RestaurantListComponent } from './restaurant/restaurant-list/restaurant-list.component';

const routes: Routes = [
  {path: 'restaurant', component: RestaurantListComponent },
  {path: '**', redirectTo: 'restaurant'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
