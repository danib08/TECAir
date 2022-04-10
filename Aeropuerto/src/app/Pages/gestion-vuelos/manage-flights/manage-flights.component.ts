import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-manage-flights',
  templateUrl: './manage-flights.component.html',
  styleUrls: ['./manage-flights.component.css']
})
export class ManageFlightsComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  get flights(){
    return this.registerForm2.get('Flights') as FormArray;
  }
  registerForm = this.formBuilder.group({
    FlightID: ['',Validators.required],
    Status: ['', Validators.required]
  });

  registerForm2 = this.formBuilder.group({
    Flights: this.formBuilder.array([], Validators.required)
  });
  addFlights(){
    const FlightsFormGroup = this.formBuilder.group({
      FlightID: '',
      Status: ''
    });
    this.flights.push(FlightsFormGroup);
  }
  removeFlights(index : number){
    this.flights.removeAt(index);
  }
  submit(){
    console.log(this.registerForm.value);
    console.log(this.flights.value);
  }
}
