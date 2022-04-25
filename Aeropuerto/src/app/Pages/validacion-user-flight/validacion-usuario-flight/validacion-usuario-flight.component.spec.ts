import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidacionUsuarioFlightComponent } from './validacion-usuario-flight.component';

describe('ValidacionUsuarioFlightComponent', () => {
  let component: ValidacionUsuarioFlightComponent;
  let fixture: ComponentFixture<ValidacionUsuarioFlightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ValidacionUsuarioFlightComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidacionUsuarioFlightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
