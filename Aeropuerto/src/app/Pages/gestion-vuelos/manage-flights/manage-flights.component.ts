import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { PatchService } from 'src/app/Services/patch-service';

@Component({
  selector: 'app-manage-flights',
  templateUrl: './manage-flights.component.html',
  styleUrls: ['./manage-flights.component.css']
})
export class ManageFlightsComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private apiService: PatchService) { }

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
}
