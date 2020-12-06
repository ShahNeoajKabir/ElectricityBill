import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignMeterComponent } from './assign-meter.component';

describe('AssignMeterComponent', () => {
  let component: AssignMeterComponent;
  let fixture: ComponentFixture<AssignMeterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssignMeterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignMeterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
