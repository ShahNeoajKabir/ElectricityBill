import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMeterReaderComponent } from './list-meter-reader.component';

describe('ListMeterReaderComponent', () => {
  let component: ListMeterReaderComponent;
  let fixture: ComponentFixture<ListMeterReaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListMeterReaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListMeterReaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
