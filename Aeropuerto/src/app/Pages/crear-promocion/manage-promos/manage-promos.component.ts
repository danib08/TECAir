import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { GetService } from 'src/app/Services/get-service';
import { PatchService } from 'src/app/Services/patch-service';
import { PutService } from 'src/app/Services/put-service';
import { CustomerModel } from '../../models/customer';
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
    flightid: '',
    price: 0
  }

  /**
   * Constructor method
   */
  constructor(private formBuilder: FormBuilder, private apiService: PutService, private apiServiceGET:GetService) { }

  /**
   * Method to be executed at component startup
   */
  ngOnInit(): void {
    this.getFlights();
  }

  /**
   * Get the discounts FormArray
   */
  get discounts(){
    return this.registerForm2.get('Discounts') as FormArray;
  }

  /**
   * Get the flightid from the FormGroup
   */
  get flightID(){
    return this.registerForm.get('flightid');
  }

  /**
   * Get the discount from the FormGroup
   */
  get discount(){
    return this.registerForm.get('discount');
  }

  registerForm = this.formBuilder.group({
    flightid: ['',Validators.required],
    discount: [0, Validators.required],
    origin: '',
    destination: '',
    bagquantity: 0,
    userquantity: 0,
    departure: '',
    arrival: '',
    price: 0,
    stops: [],
    gate: '',
    status: '',
    planeid: '',
    workerid: 0
  });

  registerForm2 = this.formBuilder.group({
    Discounts: this.formBuilder.array([], Validators.required)
  });

  /**
   * Add the extra discounts to an array
   */
  addDiscounts(){
    const discountsFormGroup = this.formBuilder.group({
      flightid: '',
      discount: 0,
      origin: '',
      destination: '',
      bagquantity: 0,
      userquantity: 0,
      departure: '',
      arrival: '',
      price: 0,
      stops: [],
      gate: '',
      status: '',
      planeid: '',
      workerid: 0
    });
    this.discounts.push(discountsFormGroup);
  }

  /**
   * Delete an item from the discounts array 
   * @param index 
   */
  removeDiscounts(index : number){
    this.discounts.removeAt(index);
  }

  /**
   * Send the data through http methods
   * @returns 
   */
  submit(){
    let flag = false;
    if(this.discounts.length != 0){
      flag = true;
    }
    if(!this.registerForm.valid){
      alert("ERROR");
      return;
    }
    else{
      this.apiService.changeStatus(this.registerForm.value).subscribe(
        res => {
          if(flag == false){
            location.reload()
          }
          console.log(res);
        },err=>{
          alert("Ha ocurrido un error")
        }
      );
      if(this.discounts.length != 0){
        for (let i = 0; i< this.discounts.length; i++){
          this.apiService.changeStatus(this.discounts.at(i).value).subscribe(
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

  /**
   * Http Get call for all the flights
   */
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

  /**
   * Http Get call for a specific price 
   * @param ID 
   */
  getPrice(ID:string){
    this.apiServiceGET.getPrice(ID).subscribe(
      res =>{
        this.flightPrice = res;
      }
    );
  }

  /**
   * Get a specific price from the flightsArray
   * @param ID 
   * @returns 
   */
  getFlightPrice(ID:string): number{
    let value = 0;
    for(let i = 0; i < this.flightsArray.length; i++){
      if (this.flightsArray[i].flightid == ID){
        value = this.flightsArray[i].price;
        break;
      }
    }
    return value;
  }

}

