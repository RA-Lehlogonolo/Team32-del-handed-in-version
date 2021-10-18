import { TestBed } from '@angular/core/testing';

import { DisciplinaryHearingService } from './disciplinary-hearing.service';

describe('DisciplinaryHearingService', () => {
  let service: DisciplinaryHearingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DisciplinaryHearingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
