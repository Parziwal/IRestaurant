import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { faEdit, faTrashAlt } from '@fortawesome/free-regular-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subject, Subscription } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FoodService } from '../../food.service';
import { Food } from '../../models/food.type';

@Component({
  selector: 'app-food-list',
  templateUrl: './food-list.component.html',
  styleUrls: ['./food-list.component.css']
})
export class FoodListComponent implements OnInit, OnDestroy {

  @Output()
  foodEdit = new EventEmitter<{foodId: number}>();
  @Input()
  refreshFoodList: Subject<boolean> = new Subject<boolean>();
  refreshSubscription: Subscription;
  foods: Observable<Food[]> = new Observable();
  defaultFoodImgUrl = environment.defaultFoodImgUrl;
  faEdit = faEdit;
  faTrashAlt = faTrashAlt;

  constructor(private foodService: FoodService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadFoods();
    this.subscribeToRefresh();
  }

  ngOnDestroy(): void {
    this.refreshSubscription.unsubscribe();
  }

  private loadFoods() {
    this.foods = this.foodService.getMyRestaurantMenu();
  }

  private subscribeToRefresh() {
    this.refreshSubscription = this.refreshFoodList.subscribe(response => {
      if(response){
        this.loadFoods();
      }
    });
  }

  editFood(foodId: number) {
    this.foodEdit.emit({foodId: foodId});
  }

  deleteFood(foodId: number) {
    this.foodService.RemoveFoodFromMenu(foodId).subscribe(
      response => {
        this.toastr.success("Az étel törlésre került!");
        this.loadFoods();
      }
    );
  }
}
