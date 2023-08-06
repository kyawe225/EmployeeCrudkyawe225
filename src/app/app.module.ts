import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { DepartmentPositionModule } from './admin/department-position/department-position.module';
import { DepartmentPositionComponent } from './department-position/department-position.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    AppComponent,
    DepartmentPositionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DepartmentPositionModule,
    // RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
