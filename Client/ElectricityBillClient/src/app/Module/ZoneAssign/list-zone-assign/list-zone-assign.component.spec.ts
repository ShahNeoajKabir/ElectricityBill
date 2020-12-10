import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListZoneAssignComponent } from './list-zone-assign.component';

describe('ListZoneAssignComponent', () => {
  let component: ListZoneAssignComponent;
  let fixture: ComponentFixture<ListZoneAssignComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListZoneAssignComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListZoneAssignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
