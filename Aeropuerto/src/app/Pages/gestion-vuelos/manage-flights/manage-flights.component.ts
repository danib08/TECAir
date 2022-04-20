import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { GetService } from 'src/app/Services/get-service';
import { PatchService } from 'src/app/Services/patch-service';
import { PutService } from 'src/app/Services/put-service';
import { FlightModel } from '../../models/flight.model';

@Component({
  selector: 'app-manage-flights',
  templateUrl: './manage-flights.component.html',
  styleUrls: ['./manage-flights.component.css']
})
export class ManageFlightsComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private apiService: PutService, private apiServiceGET:GetService) { }

  flightsArray: FlightModel[] = [];
  
  ngOnInit(): void {
    this.getFlights();
  }

  get flights(){
    return this.registerForm2.get('Flights') as FormArray;
  }
  registerForm = this.formBuilder.group({
    flightid: ['',Validators.required],
    status: ['', Validators.required],
    origin: '',
    destination: '',
    bagquantity: 0,
    userquantity: 0,
    departure: '',
    arrival: '',
    price: 0,
    stops: [],
    gate: '',
    discount: 0,
    planeid: '',
    workerid: 0
  });

  registerForm2 = this.formBuilder.group({
    Flights: this.formBuilder.array([], Validators.required)
  });
  addFlights(){
    const FlightsFormGroup = this.formBuilder.group({
      flightid: '',
      status: '',
      origin: '',
      destination: '',
      bagquantity: 0,
      userquantity: 0,
      departure: '',
      arrival: '',
      price: 0,
      stops: [],
      gate: '',
      discount: 0,
      planeid: '',
      workerid: 0
    });
    this.flights.push(FlightsFormGroup);
  }
  removeFlights(index : number){
    this.flights.removeAt(index);
  }
  submit(){
    let flag = false;
    if(this.flights.length != 0){
      flag = true;
    }
    if(!this.registerForm.valid){
      alert("ERROR");
      return;
    }
    else{
      console.log(this.registerForm.value)
      this.apiService.changeStatus(this.registerForm.value).subscribe(
        res => {
          if(flag == false){
            location.reload()
          }
          console.log(res);
        }, err=>{
          alert("Ha ocurrido un error")
        }
      );
      if(this.flights.length != 0){
        for (let i = 0; i< this.flights.length; i++){
          this.apiService.addDiscount(this.flights.at(i).value).subscribe(
            res => {
              console.log(res);
            },err =>{
              alert("Ha ocurrido un error")
            }
          );
        }
        location.reload();
      }

      
      
    }
  }
  getFlights(){
    this.apiServiceGET.getFlights().subscribe(
      res => {
        this.flightsArray = res;
      },
      err => {
        alert("Ha ocurrido un error")
      }
      
    );
  }

}
