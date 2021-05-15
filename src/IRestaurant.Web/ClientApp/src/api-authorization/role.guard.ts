import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApplicationPaths, QueryParameterNames, UserRole } from './api-authorization.constants';
import { AuthorizeService } from './authorize.service';

@Injectable({
  providedIn: 'root'
})

/**
 * Ezen osztály segítségével kontrolálhatjuk, hogy mely oldalakhoz férhetnek hozzá az egyes felhasználók,
 * a szerpekörüknek megfelelően. Az útvonalválasztónak átadott data objektumban tároljuk a kívánt
 * szerepkört, akinek jogosultsága van az oldal megtekintéséshez.
 */
export class RoleGuard implements CanActivate {
  constructor(private authorize: AuthorizeService, private router: Router) {
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      return this.authorize.getUserRole().pipe(map(
        role => {
          if (role === UserRole.None) {
            return this.router.createUrlTree(ApplicationPaths.LoginPathComponents, {
              queryParams: {
                [QueryParameterNames.ReturnUrl]: state.url
              }
            });
          }

          if (route.data.role && route.data.role === role) {
            return true;
          }

          return this.router.createUrlTree([]);
        }
      ));
  }
  
}
