import { ArrayType } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { GetService } from 'src/app/Services/get-service';
import { UserInFlightModel } from '../models/user-in-flight-model';
import { FlightCapModel } from '../models/flight-cap-model';
@Component({
  selector: 'app-asientos',
  templateUrl: './asientos.component.html',
  styleUrls: ['./asientos.component.css']
})
export class AsientosComponent implements OnInit {

  customerArray: UserInFlightModel[] = [];

  capacity: FlightCapModel = {
    flightid: '',
    passangercap: 0
  }

  Status = false;
  constructor(private cookieSvc:CookieService,private router:Router, private ApiService: GetService) { 

  }

  ngOnInit(){
    this.getUserCapacity();
    this.makeMatrix();
    this.getUserInFlight();
    this.setArray();
  }

  array: Array<number> = [];
  numSeats: number = 0;
  arr_name:number[][]=[[]];
  cont = 0;

  getUserInFlight(){
    let flight = this.cookieSvc.get("FlightID");
    this.ApiService.getCustomerInFlight(flight).subscribe(
      res =>{
        this.customerArray = res;
        console.log(this.customerArray);
      },
      err => {
        alert("Ha ocurrido un error")
      }
    );
  }

  getUserCapacity(){
    let flight = this.cookieSvc.get("FlightID");
    this.ApiService.getFlightCapacity(flight).subscribe(
      res =>{
        this.capacity = res;
        this.numSeats = this.capacity.passangercap;
        console.log(this.numSeats);
      },
      err => {
        alert("Ha ocurrido un error")
      }
    );
  }


  setArray(){
    for(let i = 0; i < this.customerArray.length; i++){
      this.array.push(this.customerArray[i].seatnumber);
    }
    this.Status = true;
  }
  
  getNumber(number:Number){
    this.cookieSvc.set("seatNumber", number.toString());
  }

  checkPago(){
    this.router.navigate(["reservacionVuelo"]);
  }

  makeMatrix(){
    this.arr_name = [];
    for(var i: number = 0; i < this.numSeats/10; i++) {
        this.arr_name[i] = [];
        for(var j: number = 0; j < 10; j++) {
          this.arr_name[i][j]=this.cont;
          this.cont+=1;
        }
    }
  }

  truth(valor:number){
    if (this.array.includes(valor)){
      return true;
    }else{
      return false;
    }
  }

  

}