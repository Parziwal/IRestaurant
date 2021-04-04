import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { faEdit, faPlusSquare, faTrashAlt } from '@fortawesome/free-regular-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { environment } from 'src/environments/environment';
import { FoodService } from '../food.service';
import { Food } from '../models/food.type';
import { EditFoodDialogComponent } from './edit-food-dialog/edit-food-dialog.component';

@Component({
  selector: 'app-edit-food-list',
  templateUrl: './edit-food-list.component.html',
  styleUrls: ['./edit-food-list.component.css']
})
export class EditFoodListComponent implements OnInit {

  foods: Observable<Food[]> = new Observable()
  defaultFoodImgUrl = environment.defaultFoodImgUrl;
  faEdit = faEdit;
  faTrashAlt = faTrashAlt;
  faPlusSquare = faPlusSquare;

  constructor(private foodService: FoodService,
    private toastr: ToastrService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getFoods();
  }

  private getFoods() {
    this.foods = this.foodService.getMyRestaurantMenu();
  }

  addFood() {
    const dialogRef = this.dialog.open(EditFoodDialogComponent, {
      width: "500px"
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getFoods();
      }
    });
  }

  editFood(food: Food) {
    const dialogRef = this.dialog.open(EditFoodDialogComponent, {
      data: food,
      width: "500px"
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getFoods();
      }
    });
  }

  deleteFood(food: Food) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      disableClose: false
    });
    dialogRef.componentInstance.confirmMessage = "Biztosan törölni szeretnéd?"

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.foodService.removeFoodFromMenu(food.id).subscribe(
          response => {
            this.toastr.success("Az étel törlésre került!");
            this.getFoods();
          }
        ); 
      }
    });
  }
}
