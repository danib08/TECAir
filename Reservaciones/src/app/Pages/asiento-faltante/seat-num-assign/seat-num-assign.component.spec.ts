import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatNumAssignComponent } from './seat-num-assign.component';

describe('SeatNumAssignComponent', () => {
  let component: SeatNumAssignComponent;
  let fixture: ComponentFixture<SeatNumAssignComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeatNumAssignComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SeatNumAssignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
