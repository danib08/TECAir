import { Component, OnInit } from '@angular/core';
import { FlightModel } from '../models/flight.model';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
// Test for displaying all the flights


@Component({
  selector: 'app-busqueda-vuelo',
  templateUrl: './busqueda-vuelo.component.html',
  styleUrls: ['./busqueda-vuelo.component.css']
})
export class BusquedaVueloComponent implements OnInit {

  constructor(private router:Router, private cookieSvc:CookieService) { }

  Estado=false;

  //List with all the flights
  listVuelos: FlightModel[] = [];
  ngOnInit(): void {
  }
  //Testing the button
  mostrarInfo(event: { preventDefault: () => void; target: any; }){
    this.Estado=true;
  }
  getListaVuelos(event: { preventDefault: () => void; target: any; }){
    //Ask API for all the flight that comes form Origin to Destination
  }

  connectReservacion(VueloID:string){
    console.log(VueloID)
    this.cookieSvc.set("IDVuelo", VueloID);
    this.router.navigate(["reservacionVuelo"])
  }
}
