import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { faPlus, faTimes } from '@fortawesome/free-solid-svg-icons';
import { Observable } from 'rxjs';
import { FoodService } from 'src/app/food/food.service';
import { Food } from 'src/app/food/models/food.type';
import { OrderFoodWithId } from '../../models/order-food-with-id.type';
import { OrderService } from '../../order.service';

@Component({
  selector: 'app-choose-foods',
  templateUrl: './choose-foods.component.html',
  styleUrls: ['./choose-foods.component.css']
})
export class ChooseFoodsComponent implements OnInit {

  foods: Observable<Food[]> = new Observable();
  chosenFoods: OrderFoodWithId[] = [];
  faPlus = faPlus;
  faTimes = faTimes
  @Output()  completed = new EventEmitter<boolean>();

  constructor(private foodService: FoodService,
    private orderService: OrderService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getRestaurantMenu();
  }

  private getRestaurantMenu() {
    this.route.params.subscribe(
      (params: Params) => {
        let restaurantId = +params.id;
        this.foods = this.foodService.getRestaurantMenu(restaurantId);
      }
    );
  }

  addFoodToList(food: Food, amount: HTMLInputElement) {
    if (amount.value == "" || amount.valueAsNumber < 1) {
      return;
    }
    let chosenFood = {id: food.id, 
      amount: amount.valueAsNumber,
      name: food.name,
      price: food.price};

    let chosenFoodIndex = this.chosenFoods.findIndex(f => f.id === food.id);
    if (chosenFoodIndex === -1) {
      this.chosenFoods.push(chosenFood);
    } else {
      this.chosenFoods[chosenFoodIndex].amount += chosenFood.amount;
    }

    amount.value = '';
    
    this.completed.emit(true);
  }

  deleteFoodFromList(orderFood: OrderFoodWithId) {
    let orderFoodIndex = this.chosenFoods.findIndex(f => f.id === orderFood.id);
    this.chosenFoods.splice(orderFoodIndex, 1);

    if (this.chosenFoods.length == 0) {
      this.completed.emit(false);
    }
  }

  get chosenFoodsTotal(): number {
    let total = 0;
    this.chosenFoods.forEach(f => {
      total += f.price * f.amount;
    });
    return total;
  }

  onNextClikced() {
    this.orderService.chosenFoodsChange.next(this.chosenFoods);
  }
}
