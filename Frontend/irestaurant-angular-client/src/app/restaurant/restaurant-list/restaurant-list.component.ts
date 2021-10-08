import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { PagedList } from 'src/app/shared/models/pagedList.type';
import { RestaurantListType } from '../models/restaurant-list-type.type';
import { RestaurantOverview } from '../models/restaurant-overview.type';
import { RestaurantSearch } from '../models/restaurant-search.type';
import { RestaurantSortBy } from '../models/restaurant-sort-by.type';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.css'],
})
export class RestaurantListComponent implements OnInit {
  /** Az éttermek áttekintő adatai. */
  restaurantOverviewPagedList: Observable<PagedList<RestaurantOverview>> =
    new Observable();

  /** A keresési feltétel. */
  search: RestaurantSearch = <RestaurantSearch>{
    nameOrShortDescriptionOrCity: '',
    sortBy: RestaurantSortBy.NAME_ASC,
  };

  private restaurantListType: RestaurantListType = RestaurantListType.All;

  constructor(
    private restaurantService: RestaurantService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getRouteData();
  }

  private getRouteData() {
    this.route.data.subscribe((data) => {
      if (data.restaurantListType) {
        this.restaurantListType = data.restaurantListType;
      }
      this.route.queryParams.subscribe((params) => {
        this.search.nameOrShortDescriptionOrCity =
          params.nameOrShortDescriptionOrCity ?? '';
        this.search.sortBy = params.sortBy ?? RestaurantSortBy.NAME_ASC;
        this.search.pageNumber = params.pageNumber ?? 1;
        this.search.pageSize = params.pageSize ?? 10;

        this.getRestaurantList();
      });
    });
  }

  /**
   * A megadott névre illeszkedő éttermek áttekintő adatainak lekérdezése.
   * A lista típusától függően, amit az útvonal adat része tartalmaz, az összes étterem,
   * vagy csak az aktuális vendég kedvenceinek lekérése.
   */
  getRestaurantList() {
    if (this.restaurantListType === RestaurantListType.Favourite) {
      this.restaurantOverviewPagedList =
        this.restaurantService.getGuestFavouriteRestaurantList(this.search);
    } else {
      this.restaurantOverviewPagedList =
        this.restaurantService.getRestaurantList(this.search);
    }
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: this.search,
    });
  }

  /**
   * A lapozási adatok változása hatására frissíti a keresési feltételeket és lekéri az új étterem listát.
   * @param pageOptions A megváltozott lapozási adatok.
   */
  pageOptionsChanged(pageOptions: PageEvent) {
    this.search.pageNumber = pageOptions.pageIndex + 1;
    this.search.pageSize = pageOptions.pageSize;
    this.getRestaurantList();
  }
}
