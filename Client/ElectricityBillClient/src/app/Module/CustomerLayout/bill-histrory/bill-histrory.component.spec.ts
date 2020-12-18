import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BillHistroryComponent } from './bill-histrory.component';

describe('BillHistroryComponent', () => {
  let component: BillHistroryComponent;
  let fixture: ComponentFixture<BillHistroryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BillHistroryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BillHistroryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
