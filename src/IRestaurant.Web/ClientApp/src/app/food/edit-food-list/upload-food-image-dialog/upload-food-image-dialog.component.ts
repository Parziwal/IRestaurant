import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { FoodService } from '../../food.service';
import { Food } from '../../models/food.type';

@Component({
  selector: 'app-upload-food-image-dialog',
  templateUrl: './upload-food-image-dialog.component.html',
  styleUrls: ['./upload-food-image-dialog.component.css']
})
export class UploadFoodImageDialogComponent {

  constructor(private dialogRef: MatDialogRef<UploadFoodImageDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public food: Food,
    private foodService: FoodService,
    private toastr: ToastrService) { }

  onImagePicked(image: File) {
    this.foodService.uploadFoodImage(this.food.id, image).subscribe(
      (imageData: {relativeImagePath: string}) => {
        this.food.imagePath = imageData.relativeImagePath;
        this.toastr.success("Az étel képe feltöltésre került.");
        this.dialogRef.close();
      }
    );
  }

  onImageDeleted() {
    this.foodService.deleteFoodImage(this.food.id).subscribe(
      () => {
        this.food.imagePath = null;
        this.toastr.success("Az étel képe törlésre került.");
        this.dialogRef.close();
      }
    );
  }
}
