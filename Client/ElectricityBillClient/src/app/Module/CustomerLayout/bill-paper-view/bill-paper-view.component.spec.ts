import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BillPaperViewComponent } from './bill-paper-view.component';

describe('BillPaperViewComponent', () => {
  let component: BillPaperViewComponent;
  let fixture: ComponentFixture<BillPaperViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BillPaperViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BillPaperViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
