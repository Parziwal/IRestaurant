import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { faUpload } from '@fortawesome/free-solid-svg-icons';
import { mimeType } from '../../validators/mime-type.validator';

@Component({
  selector: 'app-image-picker',
  templateUrl: './image-picker.component.html',
  styleUrls: ['./image-picker.component.css']
})
export class ImagePickerComponent implements OnInit {

  @Input() imagePreview: string;
  @Output() imagePicked = new EventEmitter<File>();
  @Output() imageDeleted = new EventEmitter();
  imageForm: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm() {
    this.imageForm = new FormGroup({
      image: new FormControl(null, [Validators.required], [mimeType])
    });

    this.imageForm.statusChanges.subscribe(
      (status) => {
        if (status === "VALID") {
          const reader = new FileReader();
          reader.onload = () => {
            if (this.imageForm.valid) {
              this.imagePreview = reader.result as string;
            }
          };
          reader.readAsDataURL(this.imageForm.value.image);
          this.imagePicked.emit(this.imageForm.value.image);
        }
      }
    );
  }

  onImagePicked(event: Event) {
    this.imageForm.get('image').markAsTouched();
    const imageFile = (event.target as HTMLInputElement).files[0];
    this.imageForm.patchValue({image: imageFile});
    this.imageForm.get('image').updateValueAndValidity();
  }

  onImageDeleted() {
    this.imagePreview = null;
    this.imageDeleted.emit();
  }
}
