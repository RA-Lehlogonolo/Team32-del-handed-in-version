import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageHouseParentsComponent } from './manage-house-parents.component';

describe('ManageHouseParentsComponent', () => {
  let component: ManageHouseParentsComponent;
  let fixture: ComponentFixture<ManageHouseParentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageHouseParentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageHouseParentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
