import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';

import { finalize, tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

import { GlobalService } from '../services/global/global.service';
import { MessageService } from '../services/message/message.service';
import { LoadingService } from '../services/loading/loading.service';

@Injectable({
  providedIn: 'root',
})

export class RequestInterceptor implements HttpInterceptor {

  private totalRequests: number = 0;

  constructor(
    private messageService: MessageService,
    private loadingService: LoadingService,
    private globalService: GlobalService) { }

  // global http error interceptor
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.totalRequests++;
    this.loadingService.setLoading();

    return next.handle(req).pipe(tap({
          // Operation failed; error is an HttpErrorResponse
          error: (error) => {
            // console.log('RequestInterceptor: ' + error.status);
            let msg = JSON.parse(JSON.stringify(error.error));
            this.messageService.clearError();

            if (error instanceof HttpErrorResponse && error.status != 401) {
              // console.log('RequestInterceptor: ' +  msg.detail);
              if (msg && msg.text && msg.text.length > 0 && error.status == 200) {
                // success
                this.messageService.add(msg.text);
              } else if (msg && msg.text && msg.text.length > 0) {
                this.messageService.addError(msg.text);
                // console.log('RequestInterceptor: ' +  msg);
              } else if (msg && msg.detail && msg.detail.length > 0) {
                  // backend user msg
                  this.messageService.addError(msg.detail);
              } else {
                // system error
                this.messageService.addError(error.status + ': ' + error.name);
              }
            } else if (error instanceof HttpErrorResponse && error.status == 401) {
              // Unathorized
              // we're not getting new access token after expire,
              // if we want to implement getting new access token then it should be implemented using some timer
              // TODO: for some api calls maybe we would not need to logout the user
              if (msg && msg.detail && msg.detail.length > 0) {
                // backend user msg
                console.log(msg.detail);
                this.messageService.addError(msg.detail);
              }
              this.globalService.logOut();
            }
          }, finalize: () => {
            this.totalRequests--;
            if (this.totalRequests === 0) {
              this.loadingService.unsetLoading();
            }
          },
        }),
      );
  }

}