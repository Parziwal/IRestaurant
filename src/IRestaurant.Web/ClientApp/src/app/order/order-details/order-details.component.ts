import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { OrderDetails } from '../models/order-details.type';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

  orderDetails: OrderDetails;

  constructor(private orderService: OrderService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getOrderDetails();
  }

  private getOrderDetails() {
    this.route.params.subscribe(
      (params: Params) => {
        let orderId = +params['id'];
        this.orderService.getOrderDetails(orderId).subscribe(
          (orderData: OrderDetails) => {
            this.orderDetails = orderData;
            console.log(orderData);
          }
        );
      }
    );
  }
}
