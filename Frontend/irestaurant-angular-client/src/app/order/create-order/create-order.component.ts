import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, ViewChild } from '@angular/core';
import { MatStepper, StepperOrientation } from '@angular/material/stepper';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent {

  /** A vendég kiválasztotta-e már az ételeket. */
  chooseFoodCompleted: boolean = false;
  /** A vengég megadta-e már a szállítási adatait. */
  deliveryDetailsCompleted: boolean = false;
  /** A rendelés véglegesítésre került. */
  orderFinalizationCompleted: boolean = false;
  /** A léptető HTML elem. */
  @ViewChild("stepper") stepper!: MatStepper;
  /** A léptető elem orientációja. */
  stepperOrientation: Observable<StepperOrientation>;
  /** A létrehozott rendelés azonosítója. */
  createdOrderId: number = -1;

  constructor(breakpointObserver: BreakpointObserver) {
    this.stepperOrientation = breakpointObserver.observe('(min-width: 800px)')
      .pipe(map(({matches}) => matches ? 'horizontal' : 'vertical'));
  }

  /**
   * A létrehozott rendelés azonosítójának beállítása és a rendelés véglegesítése.
   * A léptető elemet egy kis idő eltelte után kell meghívni, hogy először tudja érzékelni
   * a rendelés véglegesítése státusz megváltozását, különben nem fog a következő oldalra lépni.
   * @param createdOrderId A létrehozott rendelés azonosítója.
   */
  orderCompleted(createdOrderId: number) {
    this.orderFinalizationCompleted = true;
    this.createdOrderId = createdOrderId;
    setTimeout(() => this.stepper.next(), 1);
  }
}
