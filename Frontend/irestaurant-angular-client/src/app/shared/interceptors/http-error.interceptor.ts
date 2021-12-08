import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { Error } from '../models/error.type';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor(private toastr: ToastrService) {}

  /**
   * Ha a http kérés során  hiba lép fel, akkor elkapja azt, kiszedi a hibaüzenetet,
   * majd ezt egy toast formájában közli a felhasználóval.
   */
  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<Error>> {
    return next.handle(request).pipe(
      catchError((errorResponse: HttpErrorResponse) => {
        const error: Error = errorResponse.error as Error;
        this.toastr.error(error.title);
        return throwError(error);
      })
    );
  }
}
