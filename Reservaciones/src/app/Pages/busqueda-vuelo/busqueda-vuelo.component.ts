import { Component, OnInit } from '@angular/core';
import { Vuelos } from '../models/vuelos.model';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
// Test for displaying all the flights
const COUNTRIES: Vuelos[] = [
  {
    Origin: "Mexico",
    Destination: "United States",
    BagQuantity: 4546,
    UserQuantity: 8994,
    FlightID: "XML1",
    DepartureTime: "21:00",
    ArrivalTime:"12:47",
    Price:450
  },
  {
    Origin: "Canada",
    Destination: "United States",
    BagQuantity: 4546,
    UserQuantity: 8994,
    FlightID: "XML2",
    DepartureTime: "21:00",
    ArrivalTime:"12:47",
    Price:150
  },
  {
    Origin: "Costa Rica",
    Destination: "Canada",
    BagQuantity: 4546,
    UserQuantity: 8994,
    FlightID: "XML3",
    DepartureTime: "21:00",
    ArrivalTime:"12:47",
    Price:400
  },
  {
    Origin: "Panama",
    Destination: "España",
    BagQuantity: 4546,
    UserQuantity: 8994,
    FlightID: "XML4",
    DepartureTime: "21:00",
    ArrivalTime:"12:47",
    Price:350
  },
  {
    Origin: "Japon",
    Destination: "España",
    BagQuantity: 4546,
    UserQuantity: 8994,
    FlightID: "XML5",
    DepartureTime: "21:00",
    ArrivalTime:"12:47",
    Price:550
  },
  {
    Origin: "Peru",
    Destination: "Costa Rica",
    BagQuantity: 4546,
    UserQuantity: 8994,
    FlightID: "XML6",
    DepartureTime: "21:00",
    ArrivalTime:"12:47",
    Price:430
  },
  {
    Origin: "Uruguay",
    Destination: "Russia",
    BagQuantity: 4546,
    UserQuantity: 8994,
    FlightID: "XML7",
    DepartureTime:"21:00",
    ArrivalTime: "12:47",
    Price:40
  }
];

@Component({
  selector: 'app-busqueda-vuelo',
  templateUrl: './busqueda-vuelo.component.html',
  styleUrls: ['./busqueda-vuelo.component.css']
})
export class BusquedaVueloComponent implements OnInit {

  constructor(private router:Router, private cookieSvc:CookieService) { }

  Estado=false;

  //List with all the flights
  listVuelos= COUNTRIES;
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
