import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { Review } from '../models/review.type';
import { ReviewService } from '../review.service';

@Component({
  selector: 'app-guest-review-list',
  templateUrl: './guest-review-list.component.html',
  styleUrls: ['./guest-review-list.component.css'],
})
export class GuestReviewListComponent implements OnInit {
  /** Az aktuális vendég értékelései. */
  guestReviews: Observable<Review[]> = new Observable();

  /** Törlési ikon. */
  faTrashAlt = faTrashAlt;

  constructor(
    private reviewService: ReviewService,
    private toastr: ToastrService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getCurrentGuestReviews();
  }

  private getCurrentGuestReviews() {
    this.guestReviews = this.reviewService.getCurrentGuestReviews();
  }

  /**
   * Az értékelés törlése estén egy megerősítő dialógus ablak feldobása a felhasználónak,
   * ha jóváhagyja, akkor töröljük a megadott értékelést, és frissítjük az értékelések listáját.
   * @param review A törlendő értékelés.
   */
  deleteReview(review: Review) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      disableClose: false,
    });
    dialogRef.componentInstance.confirmMessage = 'Biztosan törölni szeretnéd?';

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.reviewService.deleteReview(review.id).subscribe(() => {
          this.toastr.success('Az értékelés törlésre került!');
          this.getCurrentGuestReviews();
        });
      }
    });
  }
}
