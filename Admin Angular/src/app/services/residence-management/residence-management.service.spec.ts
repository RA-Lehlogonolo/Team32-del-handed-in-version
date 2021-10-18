import { TestBed } from '@angular/core/testing';

import { ResidenceManagementService } from './residence-management.service';

describe('ResidenceManagementService', () => {
  let service: ResidenceManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ResidenceManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
