import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { PutService } from 'src/app/Services/put-service';

@Component({
  selector: 'app-manage-flights',
  templateUrl: './manage-flights.component.html',
  styleUrls: ['./manage-flights.component.css']
})
export class ManageFlightsComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private apiService: PutService) { }

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
        this.apiService.changeStatus(this.flights.value).subscribe(
          res => {
            console.log(res);
          }
        );
      }

      
      
    }
  }
}
