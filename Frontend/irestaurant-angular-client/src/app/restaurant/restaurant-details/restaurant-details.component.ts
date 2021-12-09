import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthService } from 'src/app/authentication/auth.service';
import { UserRole } from 'src/app/authentication/models/user-roles';
import { RestaurantDetails } from '../models/restaurant-details.type';
import { RestaurantService } from '../restaurant.service';
import { Error } from '../../shared/models/error.type';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css'],
})
export class RestaurantDetailsComponent implements OnInit, OnDestroy {
  /** Az étterem részletes adatai. */
  restaurant!: RestaurantDetails;

  /** Az étterem betöltését jelzi. */
  errorMessage: string | null = null;

  /** Az étterem azonosítója. */
  restaurantId!: number;

  /** Az aktuális felhasználó szerepköre. */
  userRole: Observable<UserRole> = new Observable();

  private ratingChangedSub = new Subscription();

  constructor(
    private authService: AuthService,
    private restaurantService: RestaurantService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getCurrentUserRole();
    this.subscribeToRatingChanged();
    this.getRestaurantId();
  }

  ngOnDestroy(): void {
    this.ratingChangedSub.unsubscribe();
  }

  private getCurrentUserRole() {
    this.userRole = this.authService.currentUserRole;
  }

  private getRestaurantId() {
    this.route.params.subscribe((params: Params) => {
      this.restaurantId = +params['id'];
      this.getRestaurantDetails();
    });
  }

  private subscribeToRatingChanged() {
    this.ratingChangedSub =
      this.restaurantService.restaurantRatingChanged.subscribe(() =>
        this.getRestaurantDetails()
      );
  }

  /**
   * Az étterem részletes adatainak lekérése.
   * Ha az aktuális oldal címe 'myrestaurant', akkor a felhasználó saját éttermének adatait kérjük le,
   * egyébként pedig az étterem azonosítója alapján kérjük le az adatokat.
   */
  private getRestaurantDetails() {
    let restaurantDetails: Observable<RestaurantDetails> = new Observable();

    if (this.route.snapshot.data['myrestaurant']) {
      restaurantDetails = this.restaurantService
        .getMyRestaurantDetails()
        .pipe(
          tap((restaurantData: RestaurantDetails) => {
            this.restaurantId = restaurantData.id;
          })
        );
    } else {
      restaurantDetails = this.restaurantService.getRestaurantDetails(
        this.restaurantId
      );
    }

    restaurantDetails.subscribe((restaurantData: RestaurantDetails) => {
      this.restaurant = restaurantData;
    },
    (error: Error) => {
      this.errorMessage = "Étterem nem elérhető!";
    });
  }

  /**
   * Az aktuális étterem hozzáadása a jelenlegi vendég kedvencei közé.
   * Csak vendég szerepkörrel rendelkező felhasználók esetén használható.
   */
  addRestaurantToFavourite() {
    this.restaurantService
      .addRestaurantToFavourite(this.restaurantId)
      .subscribe(() => {
        this.restaurant.isCurrentGuestFavourite = true;
        this.toastr.success('Az étterem hozzáadásra került a kedvencekhez.');
      });
  }

  /**
   * Az aktuális étterem eltávolítása a jelenlegi vendég a kedvencek közül.
   * Csak vendég szerepkörrel rendelkező felhasználók esetén használható.
   */
  removeRestaurantFromFavourite() {
    this.restaurantService
      .removeRestaurantFromFavourite(this.restaurantId)
      .subscribe(() => {
        this.restaurant.isCurrentGuestFavourite = false;
        this.toastr.success('Az étterem eltávolításra került a kedvencekből.');
      });
  }
  
  /**
   * Ha a rendelés gombra kattintottunk, akkor átnavigálunk a rendelés oldalra.
   */
   onOrderClicked() {
    this.router.navigate(['order'], { relativeTo: this.route });
  }
}
