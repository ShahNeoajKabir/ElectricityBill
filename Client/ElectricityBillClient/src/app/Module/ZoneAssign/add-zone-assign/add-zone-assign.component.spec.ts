import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddZoneAssignComponent } from './add-zone-assign.component';

describe('AddZoneAssignComponent', () => {
  let component: AddZoneAssignComponent;
  let fixture: ComponentFixture<AddZoneAssignComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddZoneAssignComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddZoneAssignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
