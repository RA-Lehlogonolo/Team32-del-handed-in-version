import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoveOutInspectionComponent } from './move-out-inspection.component';

describe('MoveOutInspectionComponent', () => {
  let component: MoveOutInspectionComponent;
  let fixture: ComponentFixture<MoveOutInspectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MoveOutInspectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MoveOutInspectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
