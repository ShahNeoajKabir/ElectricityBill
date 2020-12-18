import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PendingCustomerComponent } from './pending-customer.component';

describe('PendingCustomerComponent', () => {
  let component: PendingCustomerComponent;
  let fixture: ComponentFixture<PendingCustomerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PendingCustomerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PendingCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
