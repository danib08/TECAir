import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BusquedaVueloComponent } from './Pages/busqueda-vuelo/busqueda-vuelo.component';
import { GestionUsuarioComponent } from './Pages/gestion-usuario/gestion-usuario.component';
import { HomeComponent } from './Pages/home/home.component';
import { LoginComponent } from './Pages/login/login.component';
import { ReservacionVuelosComponent } from './Pages/reservacion-vuelos/reservacion-vuelos.component';

const routes: Routes = [
  {path: "home",component: HomeComponent},
  {path: "busquedaVuelo",component: BusquedaVueloComponent},
  {path: "gestionUsuario",component: GestionUsuarioComponent},
  {path: "login",component: LoginComponent},
  {path: "reservacionVuelo",component: ReservacionVuelosComponent},
  {path: "**", redirectTo: "login", pathMatch:"full"},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
