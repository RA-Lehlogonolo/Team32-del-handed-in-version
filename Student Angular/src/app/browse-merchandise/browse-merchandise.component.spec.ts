import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BrowseMerchandiseComponent } from './browse-merchandise.component';

describe('BrowseMerchandiseComponent', () => {
  let component: BrowseMerchandiseComponent;
  let fixture: ComponentFixture<BrowseMerchandiseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BrowseMerchandiseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BrowseMerchandiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
