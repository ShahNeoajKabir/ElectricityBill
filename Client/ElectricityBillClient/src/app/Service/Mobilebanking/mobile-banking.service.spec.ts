import { TestBed } from '@angular/core/testing';

import { MobileBankingService } from './mobile-banking.service';

describe('MobileBankingService', () => {
  let service: MobileBankingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MobileBankingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
