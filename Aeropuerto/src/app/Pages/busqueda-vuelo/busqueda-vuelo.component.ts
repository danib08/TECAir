import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { GetService } from 'src/app/Services/get-service';

import { PostService } from 'src/app/Services/post-service';
import { FlightSearchModel } from '../models/flight-search-model';
import { FlightModel } from '../models/flight.model';
// Test for displaying all the flights

@Component({
  selector: 'app-busqueda-vuelo',
  templateUrl: './busqueda-vuelo.component.html',
  styleUrls: ['./busqueda-vuelo.component.css']
})
export class BusquedaVueloComponent implements OnInit {

  constructor(private router:Router, private cookieSvc:CookieService,private apiService: PostService) { }

  search: FlightModel = {
    origin: '',
    destination: '',
    bagquantity: 0,
    userquantity: 0,
    flightid: '',
    departure: '',
    arrival: '',
    price: 0,
    stops: [],
    gate: '',
    status: '',
    discount: 0,
    planeid: '',
    workerid: 0
  }

  //List with all the flights
  fligthsArray:FlightModel[]=[];
  //Show the list of flights
  State=false;

  ngOnInit(): void {}

  connectReservacion(FlightID:string){
    console.log(FlightID);
    this.cookieSvc.set("FlightID", FlightID);
    this.router.navigate(["asientos"]);
  }

  getFlightsSearch(){
    this.apiService.searchFlights(this.search).subscribe(
      res => {
        this.fligthsArray = res;
        
      },
      err =>{
        alert("Ha habido un error")
      }
    );
    this.State = true;

  }
}
