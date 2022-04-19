import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { GetService } from 'src/app/Services/get-service';
import { FlightModel } from '../models/flight.model';
@Component({
  selector: 'app-reservacion-vuelos',
  templateUrl: './reservacion-vuelos.component.html',
  styleUrls: ['./reservacion-vuelos.component.css']
})
export class ReservacionVuelosComponent implements OnInit {

  Flight: FlightModel = {
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
    workerID: 0
  }
  nameCustomer = this.cookieSvc.get('CustomerName');
  lastNameCustomer = this.cookieSvc.get('CustomerLN');
  numAsiento = this.cookieSvc.get("seatNumber");
  Status = false;
  constructor(private cookieSvc:CookieService, private apiService:GetService) {
    //Method for asking the API for the information of the flight
  }
  ngOnInit(): void {
    this.getFlight();
  }

  getFlight(){
    this.apiService.getFlight(this.cookieSvc.get('FlightID')).subscribe(
      res => {
        this.Flight = res;
        this.Status = true;
      }, 
      err =>{
        alert("Ha ocurrido un error")
      }
    );
  }
}
