import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FormsModule} from "@angular/forms";
import { HttpClient, HttpClientModule} from "@angular/common/http";
import { ComponentsModule } from '../Components/components.module';
import { LoginComponent } from './login/login.component';
import { BusquedaVueloComponent } from './busqueda-vuelo/busqueda-vuelo.component';
import { GestionUsuarioComponent } from './gestion-usuario/gestion-usuario.component';
import { ReservacionVuelosComponent } from './reservacion-vuelos/reservacion-vuelos.component';
import { AsientosComponent } from './asientos/asientos.component';


@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    BusquedaVueloComponent,
    GestionUsuarioComponent,
    ReservacionVuelosComponent,
    AsientosComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    ComponentsModule
  ]
})
export class PagesModule {

}
