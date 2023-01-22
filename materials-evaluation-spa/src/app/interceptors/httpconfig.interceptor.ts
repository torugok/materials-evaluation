// from: https://www.cloudsigma.com/managing-http-requests-and-error-handling-with-angular-interceptors/
import { Injectable } from '@angular/core';

import {
  HttpInterceptor,
  HttpRequest,
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
        var message: any = '';
        if (error.error.message !== undefined) {
          message = error.error.message;
        } else if (error.error.errors !== undefined) {
          // trata erros Fluent Validation
          Object.entries(error.error.errors).forEach((entry) => {
            const [key, value] = entry;
            //@ts-ignore
            if (value.length > 0) {
              //@ts-ignore
              message = value[0];
            }
          });
        }
        this.errorDialogService.openDialog({
          message: message,
          status: error.status,
        });
        return throwError(error);
      })
    );
  }
}
