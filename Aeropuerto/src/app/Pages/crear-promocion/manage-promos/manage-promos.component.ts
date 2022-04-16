import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { GetService } from 'src/app/Services/get-service';
import { PatchService } from 'src/app/Services/patch-service';
import { FlightPriceModel } from '../../models/flight-price';
import { FlightModel } from '../../models/flight.model';

@Component({
  selector: 'app-manage-promos',
  templateUrl: './manage-promos.component.html',
  styleUrls: ['./manage-promos.component.css']
})
export class ManagePromosComponent implements OnInit {

  flightsArray: FlightModel[] = [];

  flightPrice: FlightPriceModel = {
    FlightID: '',
    Price: 0
  }
  constructor(private formBuilder: FormBuilder, private apiService: PatchService, private apiServiceGET:GetService) { }

  ngOnInit(): void {
    this.getFlights();
  }


  get discounts(){
    return this.registerForm2.get('Discounts') as FormArray;
  }

  get flightID(){
    return this.registerForm.get('FlightID');
  }

  get discount(){
    return this.registerForm.get('Discount');
  }

  registerForm = this.formBuilder.group({
    FlightID: ['',Validators.required],
    Discount: [0, Validators.required]
  });

  registerForm2 = this.formBuilder.group({
    Discounts: this.formBuilder.array([], Validators.required)
  });
  addDiscounts(){
    const discountsFormGroup = this.formBuilder.group({
      FlightID: '',
      Discount: 0
    });
    this.discounts.push(discountsFormGroup);
  }
  removeDiscounts(index : number){
    this.discounts.removeAt(index);
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
      if(this.discounts.length != 0){
        for (let i = 0; i< this.discounts.length; i++){
          this.apiService.changeStatus(this.discounts.at(i).value).subscribe(
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
        alert("Ha habido un error")
      }
      
    );
  }

  getPrice(ID:string){
    this.apiServiceGET.getPrice(ID).subscribe(
      res =>{
        this.flightPrice = res;
        
      }
    );
  }

  getFlightPrice(ID:string): number{
    let value = 0;
    for(let i = 0; i < this.flightsArray.length; i++){
      if (this.flightsArray[i].FlightID == ID){
        value = this.flightsArray[i].Price;
        break;
      }
    }
    return value;
  }

}

