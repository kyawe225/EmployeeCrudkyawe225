import { NgModule, createComponent } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListModule } from './list/list.module';
import { CreateModule } from './create/create.module';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from 'src/app/shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { CreateComponent } from './create/create.component';

const routes:Routes=[
  {
    path:'',
    component: ListComponent
  },
  {
    path:'create',
    component:CreateComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ListModule,
    NgbModalModule,
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class EmployeeModule { }
