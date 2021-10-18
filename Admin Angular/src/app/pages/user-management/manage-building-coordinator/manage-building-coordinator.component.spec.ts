import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageBuildingCoordinatorComponent } from './manage-building-coordinator.component';

describe('ManageBuildingCoordinatorComponent', () => {
  let component: ManageBuildingCoordinatorComponent;
  let fixture: ComponentFixture<ManageBuildingCoordinatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageBuildingCoordinatorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageBuildingCoordinatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
