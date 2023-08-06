import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartmentPositionComponent } from './department-position.component';

describe('DepartmentPositionComponent', () => {
  let component: DepartmentPositionComponent;
  let fixture: ComponentFixture<DepartmentPositionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DepartmentPositionComponent]
    });
    fixture = TestBed.createComponent(DepartmentPositionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
