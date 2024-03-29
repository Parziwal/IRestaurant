import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RestaurantDetails } from '../models/restaurant-details.type';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-edit-restaurant',
  templateUrl: './edit-restaurant.component.html',
  styleUrls: ['./edit-restaurant.component.css'],
})
export class EditRestaurantComponent implements OnInit {
  /** Az étterem űrlapja. */
  restaurantForm!: FormGroup;

  /** Az étterem részletes adatai betöltésre kerültek. */
  restaurantDataLoaded: boolean = false;

  /** Az étterem részletes adatai. */
  restaurant!: RestaurantDetails;

  constructor(
    private restaurantService: RestaurantService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.loadRestaurantData();
  }

  private initForm() {
    this.restaurantForm = new FormGroup({
      name: new FormControl(null, [
        Validators.required,
        Validators.maxLength(50),
      ]),
      shortDescription: new FormControl(null, [
        Validators.required,
        Validators.maxLength(300),
      ]),
      detailedDescription: new FormControl(null, [Validators.maxLength(10000)]),
      image: new FormControl(null),
      address: new FormGroup({
        zipCode: new FormControl(null, [
          Validators.required,
          Validators.min(1000),
          Validators.max(9999),
        ]),
        city: new FormControl(null, [
          Validators.required,
          Validators.maxLength(100),
        ]),
        street: new FormControl(null, [
          Validators.required,
          Validators.maxLength(200),
        ]),
        phoneNumber: new FormControl(null, [
          Validators.required,
          Validators.pattern('[0-9]{2}-[0-9]{1,2}-[0-9]{3}-[0-9]{4}'),
        ]),
      }),
    });
  }

  private loadRestaurantData() {
    this.restaurantService
      .getMyRestaurantDetails()
      .subscribe((restaurantData: RestaurantDetails) => {
        this.restaurant = restaurantData;
        this.setFormInputs(restaurantData);
        this.restaurantDataLoaded = true;
      });
  }

  /**
   * Az étterem adatainak módosítása, ha az űrlap adatai validak.
   */
  onSubmit() {
    if (this.restaurantForm.invalid) {
      return;
    }

    this.restaurantService
      .editMyRestaurant(this.restaurantForm.value)
      .subscribe((restaurantData: RestaurantDetails) => {
        this.restaurant = restaurantData;
        this.toastr.success('Az étterem elmentésre került!');
      });
  }

  /**
   * A paraméterként átadott vezérlő neve alapján a hozzá tartozó hibaüzenet lekérdezése.
   * @param controlName A vezérlő neve.
   * @returns A hibaüzenet.
   */
  getErrorMessage(controlName: string) {
    if (this.restaurantForm.get(controlName)?.hasError('required')) {
      return 'A mező kitöltése kötelező!';
    }
    if (this.restaurantForm.get(controlName)?.hasError('maxlength')) {
      return `A mező értéke nem lépheti át a(z) ${
        this.restaurantForm.get(controlName)?.errors?.maxlength.requiredLength
      } karakteres limitet!`;
    }
    if (this.restaurantForm.get(controlName)?.hasError('max')) {
      return `A mező értéke nem lehet nagyobb mint ${
        this.restaurantForm.get(controlName)?.errors?.max.max
      }!`;
    }
    if (this.restaurantForm.get(controlName)?.hasError('min')) {
      return `A mező értéke nem lehet kisebb mint ${
        this.restaurantForm.get(controlName)?.errors?.min.min
      }!`;
    }
    if (this.restaurantForm.get(controlName)?.hasError('pattern')) {
      return 'Kérlek az alábbi formátumban add meg a telefonszámot: 06-30-125-6789!';
    }

    return null;
  }

  /**
   * Megadja, hogy az étterem adatai megváltoztak-e az eredeti állapothoz képest.
   */
  get restaurantDataChanged() {
    return (
      this.restaurantForm.value.name !== this.restaurant.name ||
      this.restaurantForm.value.shortDescription !==
        this.restaurant.shortDescription ||
      this.restaurantForm.value.detailedDescription !==
        this.restaurant.detailedDescription ||
      this.restaurantForm.value.address.zipCode !==
        this.restaurant.restaurantAddress.zipCode ||
      this.restaurantForm.value.address.city !==
        this.restaurant.restaurantAddress.city ||
      this.restaurantForm.value.address.street !==
        this.restaurant.restaurantAddress.street ||
      this.restaurantForm.value.address.phoneNumber !==
        this.restaurant.restaurantAddress.phoneNumber
    );
  }

  /**
   * A visszaállítási gombra kattintva az eredeti adatok betöltése.
   */
  restoreClicked() {
    this.setFormInputs(this.restaurant);
  }

  private setFormInputs(restaurantData: RestaurantDetails) {
    this.restaurantForm.setValue({
      name: restaurantData.name,
      shortDescription: restaurantData.shortDescription,
      detailedDescription: restaurantData.detailedDescription,
      image: '',
      address: {
        zipCode: restaurantData.restaurantAddress.zipCode,
        city: restaurantData.restaurantAddress.city,
        street: restaurantData.restaurantAddress.street,
        phoneNumber: restaurantData.restaurantAddress.phoneNumber,
      },
    });
  }

  /**
   * A kiválasztott képet feltölti a szerverre, mint az étterem profil képe,
   * és frissíti a kép elérési útját.
   * @param pickedImage A kiválasztott kép.
   */
  onImagePicked(pickedImage: File) {
    this.restaurantService
      .uploadImageMyRestaurant(pickedImage)
      .subscribe((image) => {
        this.restaurant.imagePath = image.relativeImagePath;
        this.toastr.success('Az étterem profil képe feltöltésre került.');
      });
  }

  /**
   * Törli az étterem aktuális profil képét.
   */
  onImageDeleted() {
    this.restaurantService.deleteMyRestaurantImage().subscribe(() => {
      this.toastr.success('Az étterem profil képe törlésre került.');
    });
  }
}
