import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepartmentService } from '../../employee/services/department.service';
import { PositionService } from '../../employee/services/position.service';
import { Position } from 'src/app/models/apis/Position.api';
import { Department } from 'src/app/models/apis/Department.api';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {
  createForm : FormGroup
  departments : Department[] =[];
  positions:Position[]=[];
  constructor(formBuilder : FormBuilder,
    private department : DepartmentService,
    private position :PositionService){
    this.createForm=formBuilder.group(
      {
        departmentId:formBuilder.control("",[Validators.required]),
        positionId:formBuilder.control("",[Validators.required])
      }
    );
  }
  ngOnInit(){
    this.getDepartments();
    this.getPositions();
  }
  private getDepartments():void{
    this.department.getAllDepartment({}).subscribe(p=> p.status==200 ? this.departments=p.data: console.log(p.message));
  }

  private getPositions(){
    let request={
      all:true,
      departmentId:""
    }

    this.position.getAllPosition(request).subscribe(p=> p.status==200? this.positions=p.data :console.log(p.message));
  }
}
