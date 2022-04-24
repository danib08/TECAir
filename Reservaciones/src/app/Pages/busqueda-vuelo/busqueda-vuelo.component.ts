import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { GetService } from 'src/app/Services/get-service';

import { PostService } from 'src/app/Services/post-service';
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
    flightid: 'IB7811',
    departure: '2022-09-07T20:20:00',
    arrival: '2022-09-07T20:20:00',
    price: 0,
    stops: [],
    gate: 0,
    status: '',
    discount: 0,
    planeid: 'TIMJH',
    workerid: 117730482
  }

  //List with all the flights
  fligthsArray:FlightModel[]=[];
  //Show the list of flights
  State=false;

  ngOnInit(): void {}

  /**
   * Create the FlightID cookie
   * @param FlightID 
   */
  connectReservacion(FlightID:string){
    console.log(FlightID);
    this.cookieSvc.set("FlightID", FlightID);
    this.router.navigate(["pago"]);
  }

  /**
   * Http Post call to search flights
   */
  getFlightsSearch(){
    console.log(this.search)
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
