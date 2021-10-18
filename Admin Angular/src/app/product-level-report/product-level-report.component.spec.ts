import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductLevelReportComponent } from './product-level-report.component';

describe('ProductLevelReportComponent', () => {
  let component: ProductLevelReportComponent;
  let fixture: ComponentFixture<ProductLevelReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductLevelReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductLevelReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
