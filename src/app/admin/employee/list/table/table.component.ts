import { Component, EventEmitter, Input, Output } from '@angular/core';
import { EmployeeViewModel } from 'src/app/models/apis/employee.api';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent {
  @Input("employee") employee:EmployeeViewModel[]=[];
  @Output("delete") deleteAction:EventEmitter<string>=new EventEmitter<string>();
  constructor(){

  }
  delete(id:string){
    console.log("Hello")
    this.deleteAction.emit(id);
  }
}
