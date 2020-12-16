import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMobileBankingComponent } from './list-mobile-banking.component';

describe('ListMobileBankingComponent', () => {
  let component: ListMobileBankingComponent;
  let fixture: ComponentFixture<ListMobileBankingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListMobileBankingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListMobileBankingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
