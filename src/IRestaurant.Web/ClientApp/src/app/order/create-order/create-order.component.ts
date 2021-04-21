import { Component, ViewChild } from '@angular/core';
import { MatStepper } from '@angular/material/stepper';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent {

  chooseFoodCompleted: boolean = false;
  deliveryDetailsCompleted: boolean = false;
  orderFinalizationCompleted: boolean = false;
  @ViewChild("stepper") stepper: MatStepper;
  createdOrderId: number = -1;

  orderCompleted(createdOrder: {orderId: number}) {
    this.orderFinalizationCompleted = true;
    this.createdOrderId = createdOrder.orderId;
    setTimeout(() => this.stepper.next(), 10)
    
  }
}
