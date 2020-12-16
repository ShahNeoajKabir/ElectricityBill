import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMobileBankingComponent } from './add-mobile-banking.component';

describe('AddMobileBankingComponent', () => {
  let component: AddMobileBankingComponent;
  let fixture: ComponentFixture<AddMobileBankingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddMobileBankingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddMobileBankingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
