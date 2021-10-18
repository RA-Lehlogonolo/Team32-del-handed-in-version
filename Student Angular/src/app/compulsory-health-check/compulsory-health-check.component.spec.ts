import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompulsoryHealthCheckComponent } from './compulsory-health-check.component';

describe('CompulsoryHealthCheckComponent', () => {
  let component: CompulsoryHealthCheckComponent;
  let fixture: ComponentFixture<CompulsoryHealthCheckComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompulsoryHealthCheckComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompulsoryHealthCheckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
