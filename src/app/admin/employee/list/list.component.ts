import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../services/employee.service';
import { EmployeeViewModel } from 'src/app/models/apis/employee.api';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationComponent } from '../../../shared/popups/delete/confirmation.component';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  searchForm: FormGroup;
  employees: EmployeeViewModel[] = [];
  message = ""
  constructor(formBuilder: FormBuilder, private service: EmployeeService, private modalService: NgbModal) {
    this.searchForm = formBuilder.group({
      name: formBuilder.control<string>("", [Validators.required]),
      employeeId: formBuilder.control<string>("", [Validators.required]),
      departmentName: formBuilder.control<string>("", [Validators.required]),
      positionName: formBuilder.control<string>("", [Validators.required])
    });
  }
  ngOnInit(): void {
    this.getDatas();
  }

  formSubmit($event: string) {
    console.log("why three times");
    console.log(this.searchForm.value);
  }

  getDatas() {
    this.service.getAllEmployee({}).subscribe(p => console.log(p.status == 200 ? this.employees = p.data : console.log(p.message)));
  }

  openDeleteDialog(id: string) {
    let activeInstance = this.modalService.open(ConfirmationComponent);
    activeInstance.componentInstance.primaryKey = id;
    activeInstance.result.then(value => this.deleteEmployee(value));
  }

  private deleteEmployee(id: string) {
    if (id) {
      console.log("deleteing")
      this.service.delete({ id: id }).subscribe(p => {
        if (p.status == 200) {
          this.getDatas()
          this.message = p.data
        } else {
          console.log(p.message)
        }
      })
    }
  }
}
