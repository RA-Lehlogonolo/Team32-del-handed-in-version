import { TestBed } from '@angular/core/testing';

import { CampusManagementService } from './campus-management.service';

describe('CampusManagementService', () => {
  let service: CampusManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CampusManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
