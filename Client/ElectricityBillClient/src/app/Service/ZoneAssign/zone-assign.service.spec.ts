import { TestBed } from '@angular/core/testing';

import { ZoneAssignService } from './zone-assign.service';

describe('ZoneAssignService', () => {
  let service: ZoneAssignService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ZoneAssignService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
