import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPayBillComponent } from './user-pay-bill.component';

describe('UserPayBillComponent', () => {
  let component: UserPayBillComponent;
  let fixture: ComponentFixture<UserPayBillComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserPayBillComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserPayBillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
