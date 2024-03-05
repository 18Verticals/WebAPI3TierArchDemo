import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { MessagePassingService } from '../services/message-passing.service';

@Injectable()
export class CoreInterceptor implements HttpInterceptor {

  constructor(private messagePassingService:MessagePassingService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    debugger
    this.messagePassingService.sendMessage(true)
    return next.handle(request).pipe(
      tap((event: HttpEvent<any>) => {
        setTimeout(() => {
          this.messagePassingService.sendMessage(false)
        }, 500);
      }));
  }
}
