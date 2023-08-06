import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.scss']
})
export class ConfirmationComponent {

  @Input('primaryKey') primaryKey:string="";
  constructor(
    private activeModal:NgbActiveModal
  ){

  }

  fnConfirm(){
    this.activeModal.close(this.primaryKey);
  }

  fnCancel(){
    this.activeModal.close("");
  }
}
