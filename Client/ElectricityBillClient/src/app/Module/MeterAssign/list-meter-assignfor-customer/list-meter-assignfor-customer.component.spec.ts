import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMeterAssignforCustomerComponent } from './list-meter-assignfor-customer.component';

describe('ListMeterAssignforCustomerComponent', () => {
  let component: ListMeterAssignforCustomerComponent;
  let fixture: ComponentFixture<ListMeterAssignforCustomerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListMeterAssignforCustomerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListMeterAssignforCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
