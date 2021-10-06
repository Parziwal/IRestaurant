import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/authentication/auth.service';
import { UserRole } from 'src/app/authentication/models/user-roles';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { OrderOverview } from '../../../models/order-overview.type';
import { OrderStatus } from '../../../models/order-status.type';
import { OrderService } from '../../../order.service';
import { ChangeOrderStatusDialogComponent } from './change-order-status-dialog/change-order-status-dialog.component';

@Component({
  selector: 'app-order-list-item',
  templateUrl: './order-list-item.component.html',
  styleUrls: ['./order-list-item.component.css'],
})
export class OrderListItemComponent implements OnInit {
  /** A rendelés áttekintő adatai. */
  @Input() orderOverview!: OrderOverview;

  /** Az aktuális felhasználó szerepköre. */
  userRole: Observable<UserRole> = new Observable();

  constructor(
    private router: Router,
    private orderService: OrderService,
    private toastr: ToastrService,
    private authService: AuthService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getCurrentUserRole();
  }

  private getCurrentUserRole() {
    this.userRole = this.authService.currentUserRole;
  }

  /**
   * A részletes gombra kattintva a rendelés részletes oldalára való navigálás.
   */
  onDetailsButtonClicked() {
    this.router.navigate(['/order/details', this.orderOverview.id]);
  }

  /**
   * A komponenshez tartozó rendelés lemondása. Ehhez egy megerősítő dialógus ablak feldobása, aminek
   * jóváhagyása esetén az töröljük a rendelést.
   */
  onCancelOrder() {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent);
    dialogRef.componentInstance.confirmMessage =
      'Biztosan le szeretnéd mondani a rendelést?';

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.orderService
          .setOrderStatus(this.orderOverview.id, OrderStatus.CANCELLED)
          .subscribe(() => {
            this.orderOverview.status = OrderStatus.CANCELLED;
            this.orderOverview.statusInString =
              this.orderService.getOrderStatusInString(OrderStatus.CANCELLED);
            this.toastr.success('A rendelés lemondásra került.');
          });
      }
    });
  }

  /**
   * A komponenshez tartozó rendelés státuszának módosítása. Ehhez egy dialógus ablak feldobása,
   * ahol ki lehet választani a megfelelő státuszt.
   */
  onOrderStatusChange() {
    const dialogRef = this.dialog.open(ChangeOrderStatusDialogComponent, {
      data: this.orderOverview,
      width: '500px',
    });

    dialogRef.afterClosed().subscribe((status: OrderStatus) => {
      if (status != null) {
        this.orderOverview.status = status;
        this.orderOverview.statusInString =
          this.orderService.getOrderStatusInString(status);
      }
    });
  }
}
