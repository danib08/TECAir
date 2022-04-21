import { Component, OnInit } from '@angular/core';
import { GetService } from 'src/app/Services/get-service';
import { Flight } from '../models/flight';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private apiService:GetService) { }

  //List with all the flights
  flightsArray: Flight[] = [];
  flights: Array<Flight> = [];
  state = false;

  ngOnInit(): void {
    this.getFlights();
    console.log(this.flightsArray);
  }
  /**
   * @description: Method for getting all the flight for the db
   */
  getFlights(){
    this.apiService.getFlights().subscribe(
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
   * @description: Method for getting randoms flights
   */
  getRandomFlights(){
    var num;
    var pasNum;
    for(let i = 0; i < 3; i++){
      num = Math.floor(Math.random() * (2 - 0 + 1)) + 0;
      while(true){
        if(num!=pasNum){
          pasNum =  num;
          this.flights.push(this.flightsArray[num]);
          break;
        }
        else{
          num = Math.floor(Math.random() * (2 - 0 + 1)) + 0;
        }
      }
    }
    this.state = true;
  }

}
