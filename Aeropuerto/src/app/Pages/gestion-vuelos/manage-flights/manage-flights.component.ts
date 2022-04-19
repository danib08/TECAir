import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { GetService } from 'src/app/Services/get-service';
import { PatchService } from 'src/app/Services/patch-service';
import { FlightModel } from '../../models/flight.model';

@Component({
  selector: 'app-manage-flights',
  templateUrl: './manage-flights.component.html',
  styleUrls: ['./manage-flights.component.css']
})
export class ManageFlightsComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private apiService: PatchService, private apiServiceGET:GetService) { }

  flightsArray: FlightModel[] = [];
  
  ngOnInit(): void {
    this.getFlights();
  }

  get flights(){
    return this.registerForm2.get('Flights') as FormArray;
  }
  registerForm = this.formBuilder.group({
    flightid: ['',Validators.required],
    status: ['', Validators.required]
  });

  registerForm2 = this.formBuilder.group({
    Flights: this.formBuilder.array([], Validators.required)
  });
  addFlights(){
    const FlightsFormGroup = this.formBuilder.group({
      flightid: '',
      status: ''
    });
    this.flights.push(FlightsFormGroup);
  }
  removeFlights(index : number){
    this.flights.removeAt(index);
  }
  submit(){
    if(!this.registerForm.valid){
      alert("ERROR");
      return;
    }
    else{
      this.apiService.changeStatus(this.registerForm.value).subscribe(
        res => {
          console.log(res);
        }
      );
      if(this.flights.length != 0){
        for (let i = 0; i< this.flights.length; i++){
          this.apiService.addDiscount(this.flights.at(i).value).subscribe(
            res => {
              console.log(res);
            }
          );
        }
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
