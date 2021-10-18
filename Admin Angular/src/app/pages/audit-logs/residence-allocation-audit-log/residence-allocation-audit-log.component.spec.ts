import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResidenceAllocationAuditLogComponent } from './residence-allocation-audit-log.component';

describe('ResidenceAllocationAuditLogComponent', () => {
  let component: ResidenceAllocationAuditLogComponent;
  let fixture: ComponentFixture<ResidenceAllocationAuditLogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResidenceAllocationAuditLogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResidenceAllocationAuditLogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
