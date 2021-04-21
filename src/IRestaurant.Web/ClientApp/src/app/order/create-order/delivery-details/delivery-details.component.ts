import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { UserAddressWithId } from 'src/app/shared/models/user-address-with-id.type';
import { UserService } from 'src/app/user/user.service';
import { OrderService } from '../../order.service';

@Component({
  selector: 'app-delivery-details',
  templateUrl: './delivery-details.component.html',
  styleUrls: ['./delivery-details.component.css']
})
export class DeliveryDetailsComponent implements OnInit {

  deliveryForm: FormGroup;
  selectedAddressId: number = -1;
  guestAddresses: Observable<UserAddressWithId[]> = new Observable();
  @Output()  completed = new EventEmitter<boolean>();

  constructor(private userService: UserService,
    private orderService: OrderService) { }

  ngOnInit(): void {
    this.initForm();
    this.getGuestAddresses();
  }

  private initForm() {
    this.deliveryForm = new FormGroup({
        preferredDeliveryDate: new FormControl(null, [Validators.required]),
        address: new FormGroup({
          zipCode: new FormControl(null, [Validators.required, Validators.min(1000), Validators.max(9999)]),
          city: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
          street: new FormControl(null, [Validators.required, Validators.maxLength(200)]),
          phoneNumber: new FormControl(null, [Validators.required, Validators.pattern("[0-9]{2}-[0-9]{2}-[0-9]{3}-[0-9]{4}")])
        })
    });

    this.deliveryForm.valueChanges.subscribe(() => {
      if (this.deliveryForm.valid) {
        this.completed.emit(true);
      } else {
        this.completed.emit(false);
      }
    });
  }

  private getGuestAddresses() {
    this.guestAddresses = this.userService.getCurrentGuestAddressList();
  }

  onAddressSelected(address: UserAddressWithId) {
    if (address == null) {
      this.deliveryForm.controls.address.reset();
      this.deliveryForm.controls.address.enable();
      return;
    }

    this.deliveryForm.controls.address.patchValue({
      zipCode: address.zipCode,
      city: address.city,
      street: address.street,
      phoneNumber: address.phoneNumber
    });
    this.deliveryForm.controls.address.disable();
  }

  getErrorMessage(controlName: string) {
    if (this.deliveryForm.get(controlName).hasError("required")) {
      return "A mező kitöltése kötelező!";
    }
    if (this.deliveryForm.get(controlName).hasError("maxlength")) {
      return `A mező értéke nem lépheti át a(z) ${this.deliveryForm.get(controlName).errors.maxlength.requiredLength} karakteres limitet!`;
    }
    if (this.deliveryForm.get(controlName).hasError("min")) {
      return `A mező értéke nem lehet kisebb mint ${this.deliveryForm.get(controlName).errors.min.min}!`;
    }
  }

  onSubmit() {
    if (this.selectedAddressId == -1) {
      this.userService.createUserAddress(this.deliveryForm.controls.address.value).subscribe(
        (createdAddress: UserAddressWithId) => {
          this.changeDeliveryDetails(createdAddress.id);
        }
      );
    } else {
      this.changeDeliveryDetails(this.selectedAddressId);
    }
  }

  private changeDeliveryDetails(addressId: number) {
    this.orderService.deliveryDetailsChange.next(
      {...this.deliveryForm.value, 
      address: {...this.deliveryForm.controls.address.value, id: addressId 
    }});
  }
}
