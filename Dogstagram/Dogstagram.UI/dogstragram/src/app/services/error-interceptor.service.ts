import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpEvent, HttpHandler } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor{

  constructor() { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    return next.handle(req).pipe(
      retry(1),
      catchError((err)=> {

        if(err.status === 401){
          //refresh token or navigat to login
          alert("401");
        }
        else if( err.status === 404){
          //custom msg
          alert("404");
        }
        else if(err.status === 400){
          alert("400");
        }
        else{
          alert("500");

        }
        
        return throwError(err);
      })
    );
  }
}
