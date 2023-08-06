import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-create-string',
  templateUrl: './create-string.component.html',
  styleUrls: ['./create-string.component.scss']
})
export class CreateStringComponent {
  createForm!: FormGroup;
  @Input() title : string="";
  constructor(private formBuilder: FormBuilder,private activeModal : NgbActiveModal) {
    this.createForm=formBuilder.group({
      name: formBuilder.control("", { validators: [Validators.required] })
    });
  }
  fnConfirm(){
    this.activeModal.close(this.createForm.controls['name'].value);
  }

  fnCancel(){
    this.activeModal.close("");
  }
}
