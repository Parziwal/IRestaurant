import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { FoodService } from '../../food.service';
import { Food } from '../../models/food.type';

@Component({
  selector: 'app-edit-food-dialog',
  templateUrl: './edit-food-dialog.component.html',
  styleUrls: ['./edit-food-dialog.component.css']
})
export class EditFoodDialogComponent implements OnInit {

  foodForm: FormGroup;

  constructor(private dialogRef: MatDialogRef<EditFoodDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public food: Food,
    private foodService: FoodService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm() {
    this.foodForm = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
      price: new FormControl(null, [Validators.required, Validators.min(0)]),
      description: new FormControl(null, [Validators.maxLength(1000)]),
      image: new FormControl(null)
    });

    if (this.food) {
      this.foodForm.setValue({
        name: this.food.name,
        price: this.food.price,
        description: this.food.description,
        image: null
      });
      this.foodForm.controls.name.disable();
    }
  }

  onSubmit() {
    if (this.foodForm.invalid) {
      return;
    }

    if (!this.food) {
      this.foodService.addFoodToRestaurantMenu(this.foodForm.value).subscribe(
        (foodData: Food) => {
          this.dialogRef.close(true);
          this.toastr.success('Az étel hozzáadásra került!');
        });
    } else {
      this.foodService.editFood(this.food.id, this.foodForm.value).subscribe(
        (foodData: Food) => {
          this.dialogRef.close(true);
          this.toastr.success('Az étel módosítása sikerült!');
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
    if (this.foodForm.get(controlName).hasError("min")) {
      return `A mező értéke nem lehet kisebb mint ${this.foodForm.get(controlName).errors.min.min}!`;
    }
  }

  cancel() {
    this.dialogRef.close(false);
  }
}
