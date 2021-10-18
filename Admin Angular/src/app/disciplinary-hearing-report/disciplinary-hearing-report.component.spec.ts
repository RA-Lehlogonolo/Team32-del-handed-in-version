import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisciplinaryHearingReportComponent } from './disciplinary-hearing-report.component';

describe('DisciplinaryHearingReportComponent', () => {
  let component: DisciplinaryHearingReportComponent;
  let fixture: ComponentFixture<DisciplinaryHearingReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisciplinaryHearingReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisciplinaryHearingReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
