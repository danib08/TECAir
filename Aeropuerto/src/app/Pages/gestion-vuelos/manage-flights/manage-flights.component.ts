import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { GetService } from 'src/app/Services/get-service';
import { PutService } from 'src/app/Services/put-service';
import { FlightModel } from '../../models/flight.model';

@Component({
  selector: 'app-manage-flights',
  templateUrl: './manage-flights.component.html',
  styleUrls: ['./manage-flights.component.css']
})
export class ManageFlightsComponent implements OnInit {

  /**
   * Constructor method
   * @param formBuilder 
   * @param apiService 
   * @param apiServiceGET 
   */
  constructor(private formBuilder: FormBuilder, private apiService: PutService, private apiServiceGET:GetService) { }

  flightsArray: FlightModel[] = [];
  /**
   * Method to be executed at component startup
   */
  ngOnInit(): void {
    this.getFlights();
  }

  /**
   * Get the flights formArray
   */
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
  /**
   * add new flight to the FormArray
   */
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
  /**
   * Delete the index flight from the FormArray
   * @param index 
   */
  removeFlights(index : number){
    this.flights.removeAt(index);
  }
  /**
   * Send the new data to the api
   * @returns 
   */
  submit(){
    this.setValuesInFlights();
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
      this.apiService.changeStatus(this.registerForm.value, this.registerForm.get('flightid')?.value).subscribe(
        res => {
          if(flag == false){
            location.reload()
          }
          console.log(res);
        },err=>{
          alert("Ha ocurrido un error")
        }
      );
      if(this.flights.length != 0){
        for (let i = 0; i< this.flights.length; i++){
          this.apiService.changeStatus(this.flights.at(i).value, this.flights.at(i).get('flightid')?.value).subscribe(
            res => {
              console.log(res);
            },err=>{
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

  setValuesInFlights(){
    for(let i = 0; i < this.flightsArray.length; i++){
      if(this.flightsArray[i].flightid == this.registerForm.get('flightid')?.value){
        this.registerForm.get('origin')?.setValue(this.flightsArray[i].origin);
        this.registerForm.get('destination')?.setValue(this.flightsArray[i].destination);
        this.registerForm.get('bagquantity')?.setValue(this.flightsArray[i].bagquantity);
        this.registerForm.get('userquantity')?.setValue(this.flightsArray[i].userquantity);
        this.registerForm.get('departure')?.setValue(this.flightsArray[i].departure);
        this.registerForm.get('arrival')?.setValue(this.flightsArray[i].arrival);
        this.registerForm.get('price')?.setValue(this.flightsArray[i].price);
        this.registerForm.get('stops')?.setValue(this.flightsArray[i].stops);
        this.registerForm.get('gate')?.setValue(this.flightsArray[i].gate);
        this.registerForm.get('discount')?.setValue(this.flightsArray[i].discount);
        this.registerForm.get('planeid')?.setValue(this.flightsArray[i].planeid);
        this.registerForm.get('workerid')?.setValue(this.flightsArray[i].workerid);
      }
    }
    if(this.flights.length != 0){
      for(let i = 0; i < this.flights.length; i++){
        for(let j = 0; j < this.flightsArray.length; j++){
          if(this.flightsArray[j].flightid == this.flights.at(i).get('flightid')?.value){
            this.flights.at(i).get('origin')?.setValue(this.flightsArray[j].origin);
            this.flights.at(i).get('destination')?.setValue(this.flightsArray[j].destination);
            this.flights.at(i).get('bagquantity')?.setValue(this.flightsArray[j].bagquantity);
            this.flights.at(i).get('userquantity')?.setValue(this.flightsArray[j].userquantity);
            this.flights.at(i).get('arrival')?.setValue(this.flightsArray[j].arrival);
            this.flights.at(i).get('price')?.setValue(this.flightsArray[j].price);
            this.flights.at(i).get('stops')?.setValue(this.flightsArray[j].stops);
            this.flights.at(i).get('gate')?.setValue(this.flightsArray[j].gate);
            this.flights.at(i).get('discount')?.setValue(this.flightsArray[j].discount);
            this.flights.at(i).get('planeid')?.setValue(this.flightsArray[j].planeid);
            this.flights.at(i).get('workerid')?.setValue(this.flightsArray[j].workerid);
            this.flights.at(i).get('departure')?.setValue(this.flightsArray[j].departure);
          }
        }
      }
    }
  }
}


