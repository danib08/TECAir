import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservacionVuelosComponent } from './reservacion-vuelos.component';

describe('ReservacionVuelosComponent', () => {
  let component: ReservacionVuelosComponent;
  let fixture: ComponentFixture<ReservacionVuelosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReservacionVuelosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservacionVuelosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
