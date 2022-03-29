import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusquedaVueloComponent } from './busqueda-vuelo.component';

describe('BusquedaVueloComponent', () => {
  let component: BusquedaVueloComponent;
  let fixture: ComponentFixture<BusquedaVueloComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusquedaVueloComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusquedaVueloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
