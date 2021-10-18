import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuRotationComponent } from './menu-rotation.component';

describe('MenuRotationComponent', () => {
  let component: MenuRotationComponent;
  let fixture: ComponentFixture<MenuRotationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuRotationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuRotationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
