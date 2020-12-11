import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListUnitPriceComponent } from './list-unit-price.component';

describe('ListUnitPriceComponent', () => {
  let component: ListUnitPriceComponent;
  let fixture: ComponentFixture<ListUnitPriceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListUnitPriceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListUnitPriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
