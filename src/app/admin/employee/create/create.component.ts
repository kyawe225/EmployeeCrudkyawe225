import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Department } from 'src/app/models/apis/Department.api';
import { DepartmentService } from '../services/department.service';
import { Position } from 'src/app/models/apis/Position.api';
import { PositionService } from '../services/position.service';
import { DepartmentPositionService } from '../services/department-position.service';
import { EmployeeService } from '../services/employee.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CreateStringComponent } from '../../../shared/popups/create-string/create-string.component';

interface DepartmentPosition{
  departmentName:string,
  positionName:string,
  departmentId:string,
  positionId:string,
  id:string
}


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit,OnDestroy{
  employeeForm:FormGroup;
  departments:Department[]=[];
  departmentPositionArr:DepartmentPosition[]=[];
  positions : Position[]=[];

  message:string="";

  constructor(formBuilder : FormBuilder,
    private department:DepartmentService,
    private position : PositionService,
    private departmentPosition: DepartmentPositionService,
    private employeeService:EmployeeService,
    private modalService:NgbModal){
    this.employeeForm=formBuilder.group({
      firstName:formBuilder.control("",[Validators.required]),
      lastName:formBuilder.control("",[Validators.required]),
      email: formBuilder.control("",[Validators.email,Validators.required]),
      fatherName:formBuilder.control("",[Validators.required,Validators.minLength(2),Validators.maxLength(70)]),
      DOB:formBuilder.control("",[Validators.required]),
      address:formBuilder.control("",[Validators.required]),
      departmentIds:formBuilder.control("",{updateOn:"change",validators:[Validators.required]}),
      positionIds:formBuilder.control("",{updateOn:'change'})
    })
  }

  ngOnInit(): void {
    this.getDepartments();
    this.getPositions("");
    this.employeeForm.get('departmentIds')?.valueChanges.subscribe((value)=>{
      this.getPositions(value);
    })
  }
  ngOnDestroy(): void {

  }

  private getDepartments():void{
    this.department.getAllDepartment({}).subscribe(p=> p.status==200 ? this.departments=p.data: console.log(p.message));
  }

  private getPositions(value:string){
    let request={
      all:true,
      departmentId:""
    }
    if(value){
      request.all=false;
      request.departmentId=value
    }
    this.position.getAllPosition(request).subscribe(p=> p.status==200? this.positions=p.data :console.log(p.message));
  }

  getDepartmentPosition():void{
    let departmentId=this.employeeForm.controls['departmentIds'].getRawValue();
    let positionId=this.employeeForm.controls['positionIds'].getRawValue();
    let gh= this.departmentPositionArr.filter((value)=> value.departmentId == departmentId);
    if(gh.length>0){
      return ;
    }
    if(departmentId && positionId){
      this.departmentPosition.searchExists({departmentId:departmentId,positionId:positionId}).subscribe(p=>{
        if(p.status==200){
          if(p.data){
            this.employeeForm.patchValue({
              departmentIds:"",
              positionIds:""
            })
            let tDepartment=this.departments.filter((value,index,array)=> value.id==departmentId)[0]
            let tPosition=this.positions.filter((value,index,array)=> value.id==positionId)[0]

            let tddata:DepartmentPosition={
              departmentId:tDepartment.id,
              departmentName: tDepartment.name,
              positionId:tPosition.id,
              positionName:tPosition.name,
              id:p.data.id
            }
            this.departmentPositionArr.push(tddata);
            console.log("setting")
          }
        }
      })
    }
    this.departmentPositionArr.push()
  }

  submitForm(){
    console.log(this.employeeForm.valid)
    console.log(this.employeeForm.value)
    let request={ ...this.employeeForm.value , departmentPositionIds:this.departmentPositionArr}
    console.log({ ...this.employeeForm.value , departmentPositionIds:this.departmentPositionArr});
    this.employeeService.save(request).subscribe(p=> p.status==200 ? this.message=p.data: this.message=p.message);
  }
  resetForm(){
    this.employeeForm.reset();
    this.departmentPositionArr=[];
  }
  fnCreateDepartment(){
    let modalInstance=this.modalService.open(CreateStringComponent);
    modalInstance.componentInstance.title="Create Department";
    modalInstance.result.then((value: any)=>{
      this.position.save({name : value}).subscribe((p)=> p.status==200 ? this.message=p.data : console.log(p.message));
    })
  }
  fnCreatePosition(){
    let modalInstance=this.modalService.open(CreateStringComponent);
    modalInstance.componentInstance.title="Create Position";
    modalInstance.result.then((value : any)=>{
      this.department.save({ name : value }).subscribe((p)=> p.status==200? this.message=p.data : console.log(p.message));
    })
  }
}
