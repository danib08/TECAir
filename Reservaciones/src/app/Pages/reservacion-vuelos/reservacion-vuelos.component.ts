import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Flight } from '../models/flight';
import { GetService } from 'src/app/Services/get-service';

@Component({
  selector: 'app-reservacion-vuelos',
  templateUrl: './reservacion-vuelos.component.html',
  styleUrls: ['./reservacion-vuelos.component.css']
})
export class ReservacionVuelosComponent implements OnInit {

  Flight: Flight = {
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

  correoCustomer = this.cookieSvc.get('usuarioCorreo');
  numAsiento = this.cookieSvc.get("seatNumber");
  Status = false;

  constructor(private cookieSvc:CookieService,private apiService:GetService) {}
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
