import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BagAssignComponent } from './bag-assign.component';

describe('BagAssignComponent', () => {
  let component: BagAssignComponent;
  let fixture: ComponentFixture<BagAssignComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BagAssignComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BagAssignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
