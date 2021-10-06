import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { faUpload } from '@fortawesome/free-solid-svg-icons';
import { mimeType } from '../../validators/mime-type.validator';

@Component({
  selector: 'app-image-picker',
  templateUrl: './image-picker.component.html',
  styleUrls: ['./image-picker.component.css'],
})
export class ImagePickerComponent implements OnInit {
  /** A kép előnézetének elérési útvonala. */
  @Input() imagePreview: string | null = null;

  /** Jelzi, ha a felhasználó kiválasztott egy képet. */
  @Output() imagePicked = new EventEmitter<File>();

  /** Jelzi, ha a felhasználó törölte a képet. */
  @Output() imageDeleted = new EventEmitter();

  /** A kép feltöltését tartalmazó űtlap. */
  imageForm!: FormGroup;

  constructor() {}

  ngOnInit(): void {
    this.initForm();
  }

  /**
   * A képfeltöltő űtlap inicializálása.
   * A form státuszának változása estén, ha a form valid, akkor kiolvassuk a képet
   * és egy esemény formájában értesítjük a felíratkozottakat a képfájl megváltozásáról.
   */
  private initForm() {
    this.imageForm = new FormGroup({
      image: new FormControl(null, [Validators.required], [mimeType]),
    });

    this.imageForm.statusChanges.subscribe((status) => {
      if (status === 'VALID') {
        const reader = new FileReader();
        reader.onload = () => {
          if (this.imageForm.valid) {
            this.imagePreview = reader.result as string;
          }
        };
        reader.readAsDataURL(this.imageForm.value.image);
        this.imagePicked.emit(this.imageForm.value.image);
      }
    });
  }

  /**
   * A kép kiválasztásakor a képfájl betöltése a formba és az űrlap validálásának frissítése.
   */
  onImagePicked(event: Event) {
    this.imageForm.get('image')?.markAsTouched();
    const imageFile = (event.target as HTMLInputElement).files?.item(0);
    this.imageForm.patchValue({ image: imageFile });
    this.imageForm.get('image')?.updateValueAndValidity();
  }

  /**
   * A kép törlésének jelzése.
   */
  onImageDeleted() {
    this.imagePreview = null;
    this.imageDeleted.emit();
  }
}
