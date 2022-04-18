import { Component, OnInit } from '@angular/core';
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
  constructor(private apiService: GetService) { }

  ngOnInit(): void {
    this.getFlights();
    console.log(this.flightsArray);
    
  }

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
