import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisitationReportComponent } from './visitation-report.component';

describe('VisitationReportComponent', () => {
  let component: VisitationReportComponent;
  let fixture: ComponentFixture<VisitationReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisitationReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisitationReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
