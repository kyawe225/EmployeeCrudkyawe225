import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { SidebarComponent } from './sidebar/sidebar.component';

let routes:Routes=[
  {
    path:"",
    component: AdminComponent,
    children:[
      {
        path:"employee",
        loadChildren:() => import("./employee/employee.module").then(p=> p.EmployeeModule)
      },
      {
        path:"department-position",
        loadChildren:() => import("./department-position/department-position.module").then(p=> p.DepartmentPositionModule)
      },
    ]
  }

]

@NgModule({
  declarations: [
    AdminComponent,
    SidebarComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
    RouterModule
  ]
})
export class AdminModule { }
