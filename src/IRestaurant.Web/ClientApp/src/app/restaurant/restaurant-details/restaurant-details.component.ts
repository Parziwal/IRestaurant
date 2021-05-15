import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { faStar, faTrashAlt } from '@fortawesome/free-regular-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { UserRole } from 'src/api-authorization/api-authorization.constants';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { environment } from 'src/environments/environment';
import { RestaurantDetails } from '../models/restaurant-details.type';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent implements OnInit, OnDestroy {

  /** Az étterem részletes adatai. */
  restaurant: RestaurantDetails;
  /** Az étterem azonosítója. */
  restaurantId: number;
  /** Csillag ikon. */
  faStar = faStar;
  /** Törlés ikon. */
  faTrash = faTrashAlt;
  /** Az aktuális felhasználó szerepköre. */
  userRole: Observable<UserRole>;
  private ratingChangedSub = new Subscription();

  constructor(private restaurantService: RestaurantService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private authorizeService: AuthorizeService) { }

  ngOnInit(): void {
    this.getCurrentUserRole();
    this.subscribeToRatingChanged();
    this.getRestaurantId();
    this.getRestaurantDetails();
  }

  ngOnDestroy(): void {
    this.ratingChangedSub.unsubscribe();
  }

  private getCurrentUserRole() {
    this.userRole = this.authorizeService.getUserRole();
  }

  private getRestaurantId() {
    this.route.params.subscribe(
      (params: Params) => {
        this.restaurantId = +params['id'];
      }
    );
  }

  private subscribeToRatingChanged() {
    this.ratingChangedSub = this.restaurantService.restaurantRatingChanged.subscribe(() =>
      this.getRestaurantDetails()
    );
  }

  /**
   * Az étterem részletes adatainak lekérése.
   * Ha az aktuális felhasználó szerepköre étterem és az útvonal adat részének role mezője
   * az étterem szerepkört tartalmazza, akkor a felhasználó saját éttermének adatait kérjük le,
   * egyébként pedig az étterem azonosítója alapján kérjük le az adatokat.
   */
  private getRestaurantDetails() {
    let restaurantDetails: Observable<RestaurantDetails>;
    if (this.route.snapshot.data.role === UserRole.Restaurant) {
      restaurantDetails = this.restaurantService.getMyRestaurantDetails().pipe(tap(
        (restaurantData: RestaurantDetails) => {
          this.restaurantId = restaurantData.id;
        }
      ));
    } else {
      restaurantDetails = this.restaurantService.getRestaurantDetails(this.restaurantId);
    }
    restaurantDetails.subscribe(
      (restaurantData: RestaurantDetails) => { 
        this.restaurant = restaurantData;
        if (this.restaurant.imagePath == null) {
          this.restaurant.imagePath = environment.defaultRestaurantImgUrl;
        }
      }
    );
  }

  /**
   * Az aktuális étterem hozzáadása a jelenlegi vendég kedvencei közé.
   * Csak vendég szerepkörrel rendelkező felhasználók esetén használható.
   */
  addRestaurantToFavourite() {
    this.restaurantService.addRestaurantToFavourite(this.restaurantId).subscribe(
      () => {
        this.restaurant.isCurrentGuestFavourite = true;
        this.toastr.success("Az étterem hozzáadásra került a kedvencekhez.");
      }
    );
  }

  /**
   * Az aktuális étterem eltávolítása a jelenlegi vendég a kedvencek közül.
   * Csak vendég szerepkörrel rendelkező felhasználók esetén használható.
   */
  removeRestaurantFromFavourite() {
    this.restaurantService.removeRestaurantFromFavourite(this.restaurantId).subscribe(
      () => {
        this.restaurant.isCurrentGuestFavourite = false;
        this.toastr.success("Az étterem eltávolításra került a kedvencekből.");
      }
    );
  }
}
