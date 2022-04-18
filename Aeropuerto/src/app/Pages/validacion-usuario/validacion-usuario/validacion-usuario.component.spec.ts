import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidacionUsuarioComponent } from './validacion-usuario.component';

describe('ValidacionUsuarioComponent', () => {
  let component: ValidacionUsuarioComponent;
  let fixture: ComponentFixture<ValidacionUsuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ValidacionUsuarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidacionUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
