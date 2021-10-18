import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FreshVillageManagersComponent } from './fresh-village-managers.component';

describe('FreshVillageManagersComponent', () => {
  let component: FreshVillageManagersComponent;
  let fixture: ComponentFixture<FreshVillageManagersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FreshVillageManagersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FreshVillageManagersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
