import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthInspectionReportComponent } from './health-inspection-report.component';

describe('HealthInspectionReportComponent', () => {
  let component: HealthInspectionReportComponent;
  let fixture: ComponentFixture<HealthInspectionReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HealthInspectionReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthInspectionReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
