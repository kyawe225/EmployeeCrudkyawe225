import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateStringComponent } from './create-string.component';

describe('CreateStringComponent', () => {
  let component: CreateStringComponent;
  let fixture: ComponentFixture<CreateStringComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateStringComponent]
    });
    fixture = TestBed.createComponent(CreateStringComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
