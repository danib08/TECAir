import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Flight } from '../models/flight';
import { PostService } from 'src/app/Services/post-service';

@Component({
  selector: 'app-busqueda-vuelo',
  templateUrl: './busqueda-vuelo.component.html',
  styleUrls: ['./busqueda-vuelo.component.css']
})
export class BusquedaVueloComponent implements OnInit {

  constructor(private router:Router, private cookieSvc:CookieService,private apiService: PostService) { }

  search: Flight = {
    origin: '',
    destination: '',
    bagquantity: 0,
    userquantity: 0,
    flightid: '',
    departure: '',
    arrival: '',
    price: 0,
    stops: [],
    gate: 0,
    status: '',
    discount: 0,
    planeid: '',
    workerid: 0
  }

  //List with all the flights
  fligthsArray:Flight[]=[];
  //Show the list of flights
  State=false;

  ngOnInit(): void {}

  /**
   * Http Post call to search flights
   */
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
  /**
   * Create the FlightID cookie
   * @param FlightID
   */
  connectReservacion(VueloID:string){
    console.log(VueloID)
    this.cookieSvc.set("FlightID", VueloID);
    this.router.navigate(["asientos"]);
  }
}
