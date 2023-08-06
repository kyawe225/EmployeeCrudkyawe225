import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { CreateComponent } from './create/create.component';
import { ReactiveFormsModule } from '@angular/forms';
import {  HttpClientModule } from '@angular/common/http';
import { DepartmentPositionComponent } from './department-position.component';
import { RouterModule, Routes } from '@angular/router';

let routes:Routes=[
  {
    path:"",
    component:DepartmentPositionComponent
  },
]


@NgModule({
  declarations: [
    ListComponent,
    CreateComponent,
    DepartmentPositionComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild(routes)
  ],
})
export class DepartmentPositionModule { }
