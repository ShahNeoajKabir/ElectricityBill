import { TestBed } from '@angular/core/testing';

import { MeterAssignService } from './meter-assign.service';

describe('MeterAssignService', () => {
  let service: MeterAssignService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MeterAssignService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
