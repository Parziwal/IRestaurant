import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { RestaurantOverview } from '../../models/restaurant-overview.type';

@Component({
  selector: 'app-restaurant-list-item',
  templateUrl: './restaurant-list-item.component.html',
  styleUrls: ['./restaurant-list-item.component.css']
})
export class RestaurantListItemComponent implements OnInit {

  @Input()
  restaurantOverview: RestaurantOverview;
  imageUrl: string = environment.defaultImgUrl;

  constructor(private router: Router) { }

  ngOnInit(): void {

    if (this.restaurantOverview.imagePath != null) {
      this.imageUrl = this.restaurantOverview.imagePath;
    }
  }

  onItemClicked() {
    this.router.navigate(['/restaurant/details', this.restaurantOverview.id]);
  }
}
