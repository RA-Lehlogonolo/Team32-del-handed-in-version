import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentRolesComponent } from './student-roles.component';

describe('StudentRolesComponent', () => {
  let component: StudentRolesComponent;
  let fixture: ComponentFixture<StudentRolesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentRolesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentRolesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
