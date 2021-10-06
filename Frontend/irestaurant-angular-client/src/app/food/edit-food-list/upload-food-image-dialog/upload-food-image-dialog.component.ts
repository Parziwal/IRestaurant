import { Inject } from '@angular/core';
import { Component } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { FoodService } from '../../food.service';
import { Food } from '../../models/food.type';

@Component({
  selector: 'app-upload-food-image-dialog',
  templateUrl: './upload-food-image-dialog.component.html',
  styleUrls: ['./upload-food-image-dialog.component.css'],
})
export class UploadFoodImageDialogComponent {
  constructor(
    private dialogRef: MatDialogRef<UploadFoodImageDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public food: Food,
    private foodService: FoodService,
    private toastr: ToastrService
  ) {}

  /**
   * A kiválasztott kép feltöltése a szerverre, és a visszakapott relatív elérési út
   * beállítása az ételnek.
   * @param image A feltöltendő képfájl.
   */
  onImagePicked(image: File) {
    this.foodService.uploadFoodImage(this.food.id, image).subscribe((image) => {
      this.food.imagePath = image.relativeImagePath;
      this.toastr.success('Az étel képe feltöltésre került.');
      this.dialogRef.close();
    });
  }

  /**
   * Az ételhez tartozó kép és relatíve elérési út törlése.
   */
  onImageDeleted() {
    this.foodService.deleteFoodImage(this.food.id).subscribe(() => {
      this.food.imagePath = null;
      this.toastr.success('Az étel képe törlésre került.');
      this.dialogRef.close();
    });
  }
}
