import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list.component';
import { SearchComponent } from './search/search.component';
import { TableComponent } from './table/table.component';
import { ReactiveFormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    ListComponent,
    SearchComponent,
    TableComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports:[
    ListComponent,
  ]
})
export class ListModule { }
