import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListAssignMeterComponent } from './list-assign-meter.component';

describe('ListAssignMeterComponent', () => {
  let component: ListAssignMeterComponent;
  let fixture: ComponentFixture<ListAssignMeterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListAssignMeterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListAssignMeterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
