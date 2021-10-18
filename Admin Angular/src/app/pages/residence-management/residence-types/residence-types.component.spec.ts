import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResidenceTypesComponent } from './residence-types.component';

describe('ResidenceTypesComponent', () => {
  let component: ResidenceTypesComponent;
  let fixture: ComponentFixture<ResidenceTypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResidenceTypesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResidenceTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
