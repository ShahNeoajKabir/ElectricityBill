import { TestBed } from '@angular/core/testing';

import { PaymentGetwayService } from './payment-getway.service';

describe('PaymentGetwayService', () => {
  let service: PaymentGetwayService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PaymentGetwayService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
