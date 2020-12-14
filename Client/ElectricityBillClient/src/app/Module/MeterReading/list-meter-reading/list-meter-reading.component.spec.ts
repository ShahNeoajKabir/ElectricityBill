import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMeterReadingComponent } from './list-meter-reading.component';

describe('ListMeterReadingComponent', () => {
  let component: ListMeterReadingComponent;
  let fixture: ComponentFixture<ListMeterReadingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListMeterReadingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListMeterReadingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
