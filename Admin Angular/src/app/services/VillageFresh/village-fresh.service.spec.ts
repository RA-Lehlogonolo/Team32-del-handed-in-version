import { TestBed } from '@angular/core/testing';

import { VillageFreshService } from './village-fresh.service';

describe('VillageFreshService', () => {
  let service: VillageFreshService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VillageFreshService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
