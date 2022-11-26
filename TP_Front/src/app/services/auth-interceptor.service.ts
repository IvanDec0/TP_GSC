import { HttpErrorResponse, HttpEvent, HttpHandler, HttpRequest, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, concatMap, Observable, throwError } from 'rxjs';
import { JwtDto } from '../models/jwt-dto';
import { AuthService } from './auth.service';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService {

  constructor(private tokenService:TokenService){}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>{
      let intReq = req;
    const token = this.tokenService.getToken();
        if(token != null){
          intReq = req.clone({
                setHeaders: {
                    Authorization: 'Bearer ' + token
                    }
            });
        }
        console.log(intReq);
        return next.handle(intReq);
    }
}

export const interceptorProvider = [{provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true}];


