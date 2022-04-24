import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { GetService } from 'src/app/Services/get-service';
import { FlightModel } from '../models/flight.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  flightsArray: FlightModel[] = [];
  flights: Array<FlightModel> = [];
  state = false;

  /**
   * Constructor method
   * @param apiService 
   * @param cookieSvc 
   * @param router 
   */
  constructor(private apiService: GetService, private cookieSvc:CookieService,private router:Router) { }

  /**
   * Method to be executed at component startup
   */
  ngOnInit(): void {
    this.flights = [];
    this.getFlights();
    console.log(this.flightsArray);
    this.cookieSvc.delete("FlightID");
    this.cookieSvc.delete("seatNumber");
    
  }

  /**
   * get the flights with discount from de db
   */
  getFlights(){
    this.apiService.getDiscounts().subscribe(
      res => {
        this.flightsArray = res;
        this.getRandomFlights();
        console.log(this.flights);
      },
      err => {
        alert("Ha habido un error")
      }
      
    );
  }

  /**
   * Set a random array of flights to be shown on screen
   */
  getRandomFlights(){
    var num;
    var pasNum;
    for(let i = 0; i < 3; i++){
      num = Math.floor(Math.random() * (this.flightsArray.length - 0 + 1)) + 0;
      while(true){
        if(num!=pasNum){
          pasNum =  num;
          this.flights.push(this.flightsArray[num]);
          break;
        }
        else{
          num = Math.floor(Math.random() * (this.flightsArray.length - 0 + 1)) + 0;
        }
      }
    }
    this.state = true;
  }
  /**
   * Reserve a flight with discount
   * @param num 
   */
  reserv(num: number){
    if(num == 0){
      this.cookieSvc.set('FlightID', this.flights[0].flightid.toString());
      this.router.navigate(["pago"]);
    }
    else if(num == 1){
      this.cookieSvc.set('FlightID', this.flights[1].flightid.toString());
      this.router.navigate(["pago"]);
    } else{
        this.cookieSvc.set('FlightID', this.flights[2].flightid.toString());
        this.router.navigate(["pago"]);
    }
  }
}
