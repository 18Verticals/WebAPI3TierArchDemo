import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { NavbarComponent } from './shared-layouts/navbar/navbar.component';
import { OffCanvasComponent } from './shared-layouts/off-canvas/off-canvas.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AddEditEmployeeComponent } from './components/add-edit-employee/add-edit-employee.component';
import { SpinnerComponent } from './shared-layouts/spinner/spinner.component';
import { CoreInterceptor } from './core/core.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    NavbarComponent,
    OffCanvasComponent,
    AddEditEmployeeComponent,
    SpinnerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgbModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS, useClass: CoreInterceptor, multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
