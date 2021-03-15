import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { FoodService } from '../food.service';
import { EditFood } from '../models/edit-food.type';
import { Food } from '../models/food.type';
import { FoodListComponent } from './food-list/food-list.component';

@Component({
  selector: 'app-menu',
  templateUrl: './edit-menu.component.html',
  styleUrls: ['./edit-menu.component.css']
})
export class EditMenuComponent implements OnInit {

  foodForm: FormGroup;
  edit = false;
  foodId: number;
  refreshFoodList: Subject<boolean> = new Subject<boolean>();

  constructor(private foodService: FoodService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.foodForm = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.maxLength(50), Validators.minLength(2)]),
      price: new FormControl(null, [Validators.required, Validators.min(0)]),
      description: new FormControl(null, [Validators.maxLength(1000)]),
      image: new FormControl(null)
    });
  }

  onSubmit() {
    if (this.foodForm.invalid) {
      return;
    }

    if (!this.edit) {
      this.foodService.addFoodToRestaurantMenu(this.foodForm.value).subscribe(
        (foodData: Food) => {
          this.toastr.success('Az étel hozzáadásra került!');
          this.foodForm.reset();
          this.refreshFoodList.next(true);
        });
    } else {
      this.foodService.editFood(this.foodId, {
        price: this.foodForm.value.name,
        description: this.foodForm.value.description
      }).subscribe(
        (foodData: Food) => {
          this.toastr.success('Az étel módosítása sikerült!');
          this.refreshFoodList.next(true);
        });
    }
  }

  getErrorMessage(controlName: string) {
    if (this.foodForm.get(controlName).hasError("required")) {
      return "A mező kitöltése kötelező!";
    }
    if (this.foodForm.get(controlName).hasError("maxlength")) {
      return `A mező értéke nem lépheti át a(z) ${this.foodForm.get(controlName).errors.maxlength.requiredLength} karakteres limitet!`;
    }
    if (this.foodForm.get(controlName).hasError("minlength")) {
      return `A mező értéke minimum ${this.foodForm.get(controlName).errors.minlength.requiredLength} karakter kell, hogy legyen!`;
    }
    if (this.foodForm.get(controlName).hasError("min")) {
      return `A mező értéke nem lehet kisebb mint ${this.foodForm.get(controlName).errors.min.min}!`;
    }
  }

  editFood(event: {foodId: number}) {
    this.foodId = event.foodId;
    this.foodService.getFood(event.foodId).subscribe(
      (food: Food) => {
        this.edit = true;
        this.foodForm.setValue({
          name: food.name,
          price: food.price,
          description: food.description,
          image: ""
        });
        this.foodForm.controls.name.disable();
      }
    );
  }

  cancelEdit() {
    this.foodId = null;
    this.edit = false;
    this.foodForm.controls.name.enable();
    this.foodForm.reset();
  }
}
