import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisciplinaryHearingComponent } from './disciplinary-hearing.component';

describe('DisciplinaryHearingComponent', () => {
  let component: DisciplinaryHearingComponent;
  let fixture: ComponentFixture<DisciplinaryHearingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisciplinaryHearingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisciplinaryHearingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
