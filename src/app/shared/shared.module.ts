import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateStringComponent } from './popups/create-string/create-string.component';
import { ConfirmationComponent } from './popups/delete/confirmation.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    ConfirmationComponent,
    CreateStringComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
  ]
  ,exports:[
    ConfirmationComponent,
    CreateStringComponent
  ]
})
export class SharedModule { }
