import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from '../auth.service';
import { UserRole } from '../models/user-roles';

@Injectable({
  providedIn: 'root',
})

/**
 * Ezen osztály segítségével kontrolálhatjuk, hogy az egyes oldalakhoz csak az authentikált felhasználók férhesenek hozzá.
 */
export class AuthorizeGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    return this.authService.currentUserRole.pipe(
      map((role) => {
        if (role !== UserRole.NotAuthorized) {
          return true;
        }
        return this.router.createUrlTree([]);
      })
    );
  }
}
