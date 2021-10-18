import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisitationApplicationsComponent } from './visitation-applications.component';

describe('VisitationApplicationsComponent', () => {
  let component: VisitationApplicationsComponent;
  let fixture: ComponentFixture<VisitationApplicationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisitationApplicationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisitationApplicationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
