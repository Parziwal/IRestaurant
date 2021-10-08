import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSliderModule } from '@angular/material/slider';
import { MatTabsModule } from '@angular/material/tabs';
import { MatStepperModule } from '@angular/material/stepper';
import { MatSelectModule } from '@angular/material/select';
import {
  MatPaginatorIntl,
  MatPaginatorModule,
} from '@angular/material/paginator';
import { HuPaginatorIntl } from './shared/mat-internalization/hu-paginator-intl';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatExpansionModule,
    MatSlideToggleModule,
    MatDialogModule,
    MatSliderModule,
    MatTabsModule,
    MatStepperModule,
    MatSelectModule,
    MatPaginatorModule,
    MatIconModule,
  ],
  exports: [
    MatFormFieldModule,
    MatInputModule,
    MatExpansionModule,
    MatSlideToggleModule,
    MatDialogModule,
    MatSliderModule,
    MatTabsModule,
    MatStepperModule,
    MatSelectModule,
    MatPaginatorModule,
    MatIconModule,
  ],
  providers: [{ provide: MatPaginatorIntl, useClass: HuPaginatorIntl }],
})
export class AngularMaterialModule {}
