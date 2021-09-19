import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { RestaurantService } from 'src/app/restaurant/restaurant.service';
import { ReviewService } from '../../review.service';

@Component({
  selector: 'app-add-review-dialog',
  templateUrl: './add-review-dialog.component.html',
  styleUrls: ['./add-review-dialog.component.css']
})
export class AddReviewDialogComponent implements OnInit {

  /** Az értékeléshez tartozó űrlap. */
  reviewForm!: FormGroup;

  constructor(private dialogRef: MatDialogRef<AddReviewDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private restaurantId: number,
    private restaurantService: RestaurantService,
    private reviewService: ReviewService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm() {
    this.reviewForm = new FormGroup({
      title: new FormControl(null, [Validators.required, Validators.maxLength(200)]),
      rating: new FormControl(1, [Validators.required, Validators.min(1), Validators.max(5)]),
      description: new FormControl(null, [Validators.maxLength(10000)])
    });
  }

  /**
   * Az értékelés adatait tartalmazó űrlap elküldése, ha a megadott értékek érvényesek.
   * Ha a művelet sikeressen lefutott, akkor ezt visszajelezzük a dialógus ablakon keresztül.
   */
  onSubmit() {
    if (this.reviewForm.invalid) {
      return;
    }

    this.reviewService.addReviewToRestaurant({...this.reviewForm.value, restaurantId: this.restaurantId }).subscribe(
      () => {
          this.dialogRef.close(true);
          this.restaurantService.restaurantRatingChanged.next();
          this.toastr.success('Az értékelés hozzáadásra került!');
      }
    );
  }

  /**
   * A paraméterként átadott vezérlő neve alapján a hozzá tartozó hibaüzenet lekérdezése.
   * @param controlName A vezérlő neve.
   * @returns A hibaüzenet.
   */
  getErrorMessage(controlName: string) {
    if (this.reviewForm.get(controlName)?.hasError("required")) {
      return "A mező kitöltése kötelező!";
    }
    if (this.reviewForm.get(controlName)?.hasError("maxlength")) {
      return `A mező értéke nem lépheti át a(z) ${this.reviewForm.get(controlName)?.errors?.maxlength.requiredLength} karakteres limitet!`;
    }
    if (this.reviewForm.get(controlName)?.hasError("min")) {
      return `A mező értéke nem lehet kisebb mint ${this.reviewForm.get(controlName)?.errors?.min.min}!`;
    }
    if (this.reviewForm.get(controlName)?.hasError("max")) {
      return `A mező értéke nem lehet nagyobb mint ${this.reviewForm.get(controlName)?.errors?.max.max}!`;
    }

    return null;
  }

  
  /**
   * A dialógus ablak bezárása, és visszajelzés, hogy nem hoztak létre értékelést.
   */
   cancel() {
    this.dialogRef.close(false);
  }
}
