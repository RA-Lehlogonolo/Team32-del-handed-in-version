import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaintenancerequestTypeComponent } from './maintenancerequest-type.component';

describe('MaintenancerequestTypeComponent', () => {
  let component: MaintenancerequestTypeComponent;
  let fixture: ComponentFixture<MaintenancerequestTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaintenancerequestTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MaintenancerequestTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
