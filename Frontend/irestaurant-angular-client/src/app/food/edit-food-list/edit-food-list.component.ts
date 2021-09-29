import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { faEdit, faPlusSquare, faTrashAlt, faUpload } from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { environment } from 'src/environments/environment';
import { FoodService } from '../food.service';
import { Food } from '../models/food.type';
import { EditFoodDialogComponent } from './edit-food-dialog/edit-food-dialog.component';
import { UploadFoodImageDialogComponent } from './upload-food-image-dialog/upload-food-image-dialog.component';

@Component({
  selector: 'app-edit-food-list',
  templateUrl: './edit-food-list.component.html',
  styleUrls: ['./edit-food-list.component.css']
})
export class EditFoodListComponent implements OnInit {

  /** Az étteremhez tartozó ételek listája. */
  foods: Observable<Food[]> = new Observable();
  /** Szerkesztés ikon. */
  faEdit = faEdit;
  /** Törlés ikon. */
  faTrashAlt = faTrashAlt;
  /** Hozzáadás ikon. */
  faPlusSquare = faPlusSquare;
  /** Feltöltés ikon. */
  faUpload = faUpload;

  constructor(private foodService: FoodService,
    private toastr: ToastrService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getFoods();
  }

  private getFoods() {
    this.foods = this.foodService.getMyRestaurantMenu();
  }

  /**
   * Az étel hozzáadásakor a megfelelő dialógus ablak megnyitása, és sikeres hozzáadás esetén
   * az ételek újratöltése az oldalon.
   */
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

  /**
   * A paraméterként megadott étel szerkesztése. Ehhez a megfelelő dialódus ablak megnyitása, és a
   * művelet sikeres elvégzése után az ételek újratöltése az oldalon.
   * @param food A szerkesztendó étel.
   */
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

  /**
   * A paraméterként átadott étel törlése. Ehhez egy megerősítő dialógus ablak feldobása, aminek
   * jóváhagyása esetén az ételt töröljük.
   * @param food 
   */
  deleteFood(food: Food) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent);
    dialogRef.componentInstance.confirmMessage = "Biztosan törölni szeretnéd?"

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.foodService.removeFoodFromMenu(food.id).subscribe(
          () => {
            this.toastr.success("Az étel törlésre került!");
            this.getFoods();
          }
        ); 
      }
    });
  }

  onImageUpload(food: Food) {
    this.dialog.open(UploadFoodImageDialogComponent, {
      width: "500px",
      data: food
    });
  }
}
