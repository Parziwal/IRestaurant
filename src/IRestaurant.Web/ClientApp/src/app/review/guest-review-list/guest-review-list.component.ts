import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { faTrashAlt } from '@fortawesome/free-regular-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { Review } from '../models/review.type';
import { ReviewService } from '../review.service';

@Component({
  selector: 'app-guest-review-list',
  templateUrl: './guest-review-list.component.html',
  styleUrls: ['./guest-review-list.component.css']
})
export class GuestReviewListComponent implements OnInit {

  guestReviews: Observable<Review[]> = new Observable();
  faTrashAlt = faTrashAlt;

  constructor(private reviewService: ReviewService,
    private toastr: ToastrService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getCurrentGuestReviews();
  }

  private getCurrentGuestReviews() {
    this.guestReviews = this.reviewService.getCurrentGuestReviews();
  }

  deleteReview(review: Review) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      disableClose: false
    });
    dialogRef.componentInstance.confirmMessage = "Biztosan törölni szeretnéd?"

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.reviewService.deleteReview(review.id).subscribe(
          () => {
            this.toastr.success('Az értékelés törlésre került!');
            this.getCurrentGuestReviews();
          }
        );
      }
    });
  }
}
