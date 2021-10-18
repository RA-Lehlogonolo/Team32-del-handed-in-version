import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthInspectionResultsComponent } from './health-inspection-results.component';

describe('HealthInspectionResultsComponent', () => {
  let component: HealthInspectionResultsComponent;
  let fixture: ComponentFixture<HealthInspectionResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HealthInspectionResultsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthInspectionResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
