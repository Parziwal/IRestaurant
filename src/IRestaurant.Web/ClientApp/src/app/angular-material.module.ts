import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  exports: [
    MatFormFieldModule,
    MatInputModule
  ],
  imports: [
    MatFormFieldModule,
    MatInputModule
  ],
})
export class AngularMaterialModule { }
