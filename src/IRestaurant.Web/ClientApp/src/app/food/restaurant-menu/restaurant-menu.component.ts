import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
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

  @Input() restaurantId: number;
  restaurantMenu: Observable<Food[]> = new Observable();
  defaultFoodImgUrl = environment.defaultFoodImgUrl;

  constructor(private foodService: FoodService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.getRestaurantMenu();
  }

  private getRestaurantMenu() {
    this.restaurantMenu = this.foodService.getRestaurantMenu(this.restaurantId);
  }

  onOrderClicked() {
    this.router.navigate(["order"], {relativeTo: this.route});
  }
}
