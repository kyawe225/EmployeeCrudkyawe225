import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {
  @Input("input") formGroup ! : FormGroup;
  @Output("submit") submit  : EventEmitter<string>=new EventEmitter<string>();

  submitForm(){
    this.submit.emit("aaa");
  }

  resetForm(){
    this.formGroup.reset();
  }


}
