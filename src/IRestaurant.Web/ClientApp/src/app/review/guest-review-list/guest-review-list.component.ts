import { Component, OnInit } from '@angular/core';
import { faTrashAlt } from '@fortawesome/free-regular-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { GuestReview } from '../models/guest-review-type';
import { ReviewService } from '../review.service';

@Component({
  selector: 'app-guest-review-list',
  templateUrl: './guest-review-list.component.html',
  styleUrls: ['./guest-review-list.component.css']
})
export class GuestReviewListComponent implements OnInit {

  guestReviews: Observable<GuestReview[]> = new Observable();
  faTrashAlt = faTrashAlt;

  constructor(private reviewService: ReviewService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getCurrentGuestReviews();
  }

  private getCurrentGuestReviews() {
    this.guestReviews = this.reviewService.getCurrentGuestReviews();
  }

  deleteReview(review: GuestReview) {
    this.reviewService.deleteReview(review.id).subscribe(
      () => {
        this.toastr.success('Az értékelés törlésre került!');
        this.getCurrentGuestReviews();
      }
    );
  }
}
