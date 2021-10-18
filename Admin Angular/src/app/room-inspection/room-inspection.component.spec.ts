import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomInspectionComponent } from './room-inspection.component';

describe('RoomInspectionComponent', () => {
  let component: RoomInspectionComponent;
  let fixture: ComponentFixture<RoomInspectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomInspectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomInspectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
