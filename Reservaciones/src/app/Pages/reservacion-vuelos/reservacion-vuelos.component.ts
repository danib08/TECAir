import { Component, OnInit } from '@angular/core';

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
  Flightid:string="XSQ124";
  constructor() { }

  ngOnInit(): void {
  }

}
