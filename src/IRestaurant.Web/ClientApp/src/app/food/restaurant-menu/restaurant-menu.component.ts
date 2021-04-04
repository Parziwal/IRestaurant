import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FoodService } from '../food.service';
import { Food } from '../models/food.type';

@Component({
  selector: 'app-restaurant-menu',
  templateUrl: './restaurant-menu.component.html',
  styleUrls: ['./restaurant-menu.component.css']
})
export class RestaurantMenuComponent implements OnInit {

  restaurantMenu: Observable<Food[]> = new Observable();
  defaultFoodImgUrl = environment.defaultFoodImgUrl;

  constructor(private foodService: FoodService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getRestaurantMenu();
  }

  private getRestaurantMenu() {
    this.route.params.subscribe(
      (params: Params) => {
        let id = +params['id'];
        this.restaurantMenu = this.foodService.getRestaurantMenu(id);
      });
  }

}
