import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserRole } from 'src/api-authorization/api-authorization.constants';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { environment } from 'src/environments/environment';
import { FoodService } from '../food.service';
import { Food } from '../models/food.type';

@Component({
  selector: 'app-restaurant-menu',
  templateUrl: './restaurant-menu.component.html',
  styleUrls: ['./restaurant-menu.component.css']
})
export class RestaurantMenuComponent implements OnInit {

  /** Az étterem azonosítója, amihez tartozó ételeket lekérdezi. */
  @Input() restaurantId: number;
  /** Az étteremhez tartozó ételek. */
  restaurantMenu: Observable<Food[]> = new Observable();
  /** Ha egy ételhez nem tartozik kép, akkor ezt jelenítjük meg alapméretezettként. */
  defaultFoodImgUrl = environment.defaultFoodImgUrl;
  /** Az aktuális felhasználó szerepköre. */
  userRole: Observable<UserRole>;

  constructor(private foodService: FoodService,
    private authorizeService: AuthorizeService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.getRestaurantMenu();
    this.getCurrentUserRole();
  }

  private getRestaurantMenu() {
    this.restaurantMenu = this.foodService.getRestaurantMenu(this.restaurantId);
  }

  private getCurrentUserRole() {
    this.userRole = this.authorizeService.getUserRole();
  }

  /** 
   * Ha a rendelés gombra kattintottunk, akkor átnavigálunk a rendelés oldalra.
  */
  onOrderClicked() {
    this.router.navigate(["order"], {relativeTo: this.route});
  }
}
