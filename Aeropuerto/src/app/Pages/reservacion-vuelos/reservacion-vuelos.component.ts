import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
@Component({
  selector: 'app-reservacion-vuelos',
  templateUrl: './reservacion-vuelos.component.html',
  styleUrls: ['./reservacion-vuelos.component.css']
})
export class ReservacionVuelosComponent implements OnInit {

  nombreUsuario:string="Aldo Cambronero";
  gate:number=45;
  DateTimeDeparture:string="";
  DateTimeArrival:string="";
  Origin:string="CR";
  Destination:string="MDR";
  Stops:string="---";
  Price:number=0;
  Discount:number=0;
  Flightid:string="";
  numAsientos:string="";

  constructor(private cookieSvc:CookieService) {
    this.Flightid=this.cookieSvc.get("IDVuelo");
    this.numAsientos=this.cookieSvc.get("numAsiento");
    //Method for asking the API for the information of the flight
  }
  ngOnInit(): void {
  }

}
