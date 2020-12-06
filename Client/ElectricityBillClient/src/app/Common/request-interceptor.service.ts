import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpResponse } from '@angular/common/http';
import { AuthService } from './Auth/auth.service';
import { RequestMessage } from './RequestMessage';
import { finalize } from 'rxjs/internal/operators/finalize';
import { tap } from 'rxjs/internal/operators/tap';
import { LoaderService } from './loader.service';


@Injectable({
  providedIn: 'root'
})
export class RequestInterceptorService {

  constructor(private loaderService: LoaderService,
              private auth: AuthService,
             ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const requestMessage =
      new RequestMessage(this.auth.getLoggedUsername(),
        0, req.body, this.auth.getLoggedUserType());
    const customReq = req.clone({
      body: requestMessage
    });
    console.log(customReq);
    this.loaderService.startLoader();
    return next.handle(customReq).pipe(
      tap((event: any) => {
        if (event instanceof HttpResponse) {
          console.log(event);
        }
      }
      , (error: any) => {
        // this.notification.dynamic(error);
      }
      ),
      finalize(() => {
        this.loaderService.stopLoader();
      }));
  }
}
