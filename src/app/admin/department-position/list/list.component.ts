import { Component, OnInit } from '@angular/core';
import { DepartmentPosition } from 'src/app/models/apis/DepartmentPostion.api';
import { DepartmentPositionService } from '../../employee/services/department-position.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  departmentPosition:DepartmentPosition[]=[]
  constructor(private departmentPositionService : DepartmentPositionService){

  }
  ngOnInit(): void {
    this.getDatas();
  }
  getDatas() {
    this.departmentPositionService.searchAll({}).subscribe(p => console.log(p.status == 200 ? this.departmentPosition = p.data : console.log(p.message)));
  }
}
