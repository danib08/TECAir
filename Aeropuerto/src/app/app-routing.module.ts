import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BusquedaVueloComponent } from './Pages/busqueda-vuelo/busqueda-vuelo.component';
import { GestionUsuarioComponent } from './Pages/gestion-usuario/gestion-usuario.component';
import { HomeComponent } from './Pages/home/home.component';
import { LoginComponent } from './Pages/login/login.component';
import { ReservacionVuelosComponent } from './Pages/reservacion-vuelos/reservacion-vuelos.component';
import { CrearVueloComponent } from './Pages/crear-vuelo/crear-vuelo/crear-vuelo.component';
import { ManagePromosComponent } from './Pages/crear-promocion/manage-promos/manage-promos.component';
import { SignUpWorkersComponent } from './Pages/registro-trabajadores/sign-up-workers/sign-up-workers.component';
import { ManageFlightsComponent } from './Pages/gestion-vuelos/manage-flights/manage-flights.component';
import { BagAssignComponent } from './Pages/asignar-maletas/bag-assign/bag-assign.component';
import { AsientosComponent } from './Pages/asientos/asientos.component';
import { ValidacionUsuarioComponent } from './Pages/validacion-usuario/validacion-usuario/validacion-usuario.component';
import { PaymentConfirmationComponent } from './Pages/confirmacion/payment-confirmation/payment-confirmation.component';
import { SeatNumAssignComponent } from './Pages/asiento-faltante/seat-num-assign/seat-num-assign.component';
import { ValidacionUsuarioFlightComponent } from './Pages/validacion-user-flight/validacion-usuario-flight/validacion-usuario-flight.component';


const routes: Routes = [
  {path: "home",component: HomeComponent},
  {path: "busquedaVuelo",component: BusquedaVueloComponent},
  {path: "gestionUsuario",component: GestionUsuarioComponent},
  {path: "login",component: LoginComponent},
  {path: "reservacionVuelo",component: ReservacionVuelosComponent},
  {path: "crearVuelo", component: CrearVueloComponent},
  {path: "gestionPromociones", component: ManagePromosComponent},
  {path: "agregarTrabajadores", component:SignUpWorkersComponent},
  {path: "gestionVuelos", component: ManageFlightsComponent},
  {path: "asignarMaleta", component: BagAssignComponent},
  {path: "asientos", component: AsientosComponent},
  {path: "validacionUsuario", component: ValidacionUsuarioComponent},
  {path: "pago", component: PaymentConfirmationComponent},
  {path: "seatAssign", component: SeatNumAssignComponent},
  {path: "validacionUsuarioFlight", component: ValidacionUsuarioFlightComponent},
  {path: "**", redirectTo: "login", pathMatch:"full"},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
