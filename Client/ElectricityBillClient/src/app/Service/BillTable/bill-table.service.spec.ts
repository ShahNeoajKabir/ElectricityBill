import { TestBed } from '@angular/core/testing';

import { BillTableService } from './bill-table.service';

describe('BillTableService', () => {
  let service: BillTableService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BillTableService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
