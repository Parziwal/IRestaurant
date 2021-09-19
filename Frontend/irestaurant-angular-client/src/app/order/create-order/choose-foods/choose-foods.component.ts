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

  /** Az étteremhez tartozó ételek listája, amiből a vendégek rendelhetnek. */
  foods: Observable<Food[]> = new Observable();
  /** A vendég által kiválasztott ételek listája. */
  chosenFoods: OrderFoodWithId[] = [];
  /** Hozzáadás ikon. */
  faPlus = faPlus;
  /** Törlés ikon. */
  faTimes = faTimes
  /** Jelzi, ha a felhasználó már választott ki ételt. */
  @Output() chooseFoodCompleted = new EventEmitter<boolean>();

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

  /**
   * A vendég által kiválasztott étel hozzáadása a listához, ha adott meg darabszámot,
   * és az legalább 1.
   * @param food A kiválasztott étel.
   * @param amount A darabszámot tartalmazó HTML elem.
   */
  addFoodToList(food: Food, amountHTMLElement: HTMLInputElement) {
    if (amountHTMLElement.value == "" || amountHTMLElement.valueAsNumber < 1) {
      return;
    }
    let chosenFood = {
      id: food.id, 
      foodName: food.name,
      amount: amountHTMLElement.valueAsNumber,
      price: food.price
    };

    let chosenFoodIndex = this.chosenFoods.findIndex(f => f.id === food.id);
    if (chosenFoodIndex === -1) {
      this.chosenFoods.push(chosenFood);
    } else {
      this.chosenFoods[chosenFoodIndex].amount += chosenFood.amount;
    }

    amountHTMLElement.value = '';
    
    this.chooseFoodCompleted.emit(true);
  }

  /**
   * A paraméterként megadott étel törlése a vendég rendelési listájától.
   * @param orderFood A törlendő étel.
   */
  deleteFoodFromList(orderFood: OrderFoodWithId) {
    let orderFoodIndex = this.chosenFoods.findIndex(f => f.id === orderFood.id);
    this.chosenFoods.splice(orderFoodIndex, 1);

    if (this.chosenFoods.length == 0) {
      this.chooseFoodCompleted.emit(false);
    }
  }

  /**
   * A vendég által kiválasztott ételek összértéke.
   */
  get chosenFoodsTotal(): number {
    let total = 0;
    this.chosenFoods.forEach(f => {
      total += f.price * f.amount;
    });
    return total;
  }

  /**
   * A következő gombra való kattintáskor értesítjük a felíratkozottakat a kiválasztott ételek megváltozásáról.
   */
  onNextClikced() {
    this.orderService.chosenFoodsChange.next(this.chosenFoods);
  }
}
