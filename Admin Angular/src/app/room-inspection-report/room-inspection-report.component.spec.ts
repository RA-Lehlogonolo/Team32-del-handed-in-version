import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomInspectionReportComponent } from './room-inspection-report.component';

describe('RoomInspectionReportComponent', () => {
  let component: RoomInspectionReportComponent;
  let fixture: ComponentFixture<RoomInspectionReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomInspectionReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomInspectionReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
