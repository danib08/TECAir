import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FormsModule} from "@angular/forms";
import { HttpClient, HttpClientModule} from "@angular/common/http";
import { ComponentsModule } from '../Components/components.module';
import { BusquedaVueloComponent } from './busqueda-vuelo/busqueda-vuelo.component';
import { CrearVueloComponent } from './crear-vuelo/crear-vuelo/crear-vuelo.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ManagePromosComponent } from './crear-promocion/manage-promos/manage-promos.component';
import { SignUpWorkersComponent } from './registro-trabajadores/sign-up-workers/sign-up-workers.component';
import { ManageFlightsComponent } from './gestion-vuelos/manage-flights/manage-flights.component';
import { LoginComponent } from './login/login.component';
import { GestionUsuarioComponent } from './gestion-usuario/gestion-usuario.component';
import { ReservacionVuelosComponent } from './reservacion-vuelos/reservacion-vuelos.component';
import { BagAssignComponent } from './asignar-maletas/bag-assign/bag-assign.component';
import { AsientosComponent } from './asientos/asientos.component';
import { ValidacionUsuarioComponent } from './validacion-usuario/validacion-usuario/validacion-usuario.component';
import { PaymentConfirmationComponent } from './confirmacion/payment-confirmation/payment-confirmation.component';


@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    BusquedaVueloComponent,
    GestionUsuarioComponent,
    ReservacionVuelosComponent,
    CrearVueloComponent,
    ManagePromosComponent,
    SignUpWorkersComponent,
    ManageFlightsComponent,
    BagAssignComponent,
    AsientosComponent,
    ValidacionUsuarioComponent,
    PaymentConfirmationComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    ComponentsModule,
    ReactiveFormsModule
  ]
})
export class PagesModule {

}
