import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-rating-bar',
  templateUrl: './rating-bar.component.html',
  styleUrls: ['./rating-bar.component.css']
})
export class RatingBarComponent {

  /** Az értékelés értéke. */
  @Input()
  rating: number | null = null;
}
