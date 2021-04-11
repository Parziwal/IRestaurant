import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { OrderOverview } from 'src/app/order/models/order-overview.type';
import { OrderStatus } from 'src/app/order/models/order-status.type';
import { OrderService } from 'src/app/order/order.service';

@Component({
  selector: 'app-change-order-status-dialog',
  templateUrl: './change-order-status-dialog.component.html',
  styleUrls: ['./change-order-status-dialog.component.css']
})
export class ChangeOrderStatusDialogComponent implements OnInit {

  selectedStatus: OrderStatus;
  orderStatuses = [
    {status: OrderStatus.ORDER_COMPLETION, statusInString: ""},
    {status: OrderStatus.UNDER_DELIVERING, statusInString: ""},
    {status: OrderStatus.DELIVERED, statusInString: ""},
    {status: OrderStatus.CANCELLED, statusInString: ""},
  ];

  constructor(private dialogRef: MatDialogRef<ChangeOrderStatusDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public orderOverview: OrderOverview,
    private orderService: OrderService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.setUpOrderStatuses();
  }

  private setUpOrderStatuses() {
    this.orderStatuses.splice(0, this.orderOverview.status);
    if (this.orderOverview.status !== OrderStatus.PROCESSING) {
      this.orderStatuses.splice(this.orderStatuses.length - 1, 1);
    }
    this.orderStatuses.forEach(status => {
      status.statusInString = this.orderService.getOrderStatusInString(status.status);
    });
  }

  onSubmit() {
    this.orderService.setOrderStatus(this.orderOverview.id, this.selectedStatus).subscribe(
      () => {
        this.dialogRef.close(this.selectedStatus);
        this.toastr.success("A rendelés státusza sikeressen módosításra került.");
      }
    );
  }

  cancel() {
    this.dialogRef.close(null);
  }
}
