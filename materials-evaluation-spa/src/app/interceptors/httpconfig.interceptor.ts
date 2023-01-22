// from: https://www.cloudsigma.com/managing-http-requests-and-error-handling-with-angular-interceptors/
import { Injectable } from '@angular/core';

import {
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ErrorDialogService } from '../shared/error-dialog/error-dialog.service';
@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
  constructor(public errorDialogService: ErrorDialogService) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      map((event: HttpEvent<any>) => {
        return event;
      }),
      catchError((error: HttpErrorResponse) => {
        let data = {};
        data = {
          reason:
            error && error.error && error.error.reason
              ? error.error.reason
              : '',
          status: error.status,
        };
        this.errorDialogService.openDialog(data);
        return throwError(error);
      })
    );
  }
}
