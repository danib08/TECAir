import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { GetService } from 'src/app/Services/get-service';
import { PostService } from 'src/app/Services/post-service';
import { CustomerModel } from '../../models/customer';
import { FlightModel } from '../../models/flight.model';

@Component({
  selector: 'app-bag-assign',
  templateUrl: './bag-assign.component.html',
  styleUrls: ['./bag-assign.component.css']
})
export class BagAssignComponent implements OnInit {

  flightsArray: FlightModel[] = [];
  customerArray: CustomerModel[] = [];

  constructor(private formBuilder: FormBuilder, private apiServiceGET:GetService, private apiService:PostService) { }

  ngOnInit(): void {
    this.getFlights();
    this.getCustomers();
  }

  get customerID(){
    return this.registerForm.get('customerid');
  }

  get flightID(){
    return this.registerForm.get('flightid');
  }

  get weight(){
    return this.registerForm.get('weight');
  }

  get color(){
    return this.registerForm.get('color');
  }

  get bags(){
    return this.registerForm2.get('Bags') as FormArray;
  }

  registerForm = this.formBuilder.group({
    customerid: [0, Validators.required],
    weight: [0, Validators.required],
    flightid: ['',Validators.required],
    color:['', Validators.required],
    //price: 0
  });

  registerForm2 = this.formBuilder.group({
    Bags:this.formBuilder.array([])
  });

  addBags(){
    const bagsFormGroup = this.formBuilder.group({
      customerid: this.customerID?.value,
      weight: 0,
      flightid: this.flightID?.value,
      color:'',
      price: 0

    });
    this.bags.push(bagsFormGroup);
  }

  removeBags(index : number){
    this.bags.removeAt(index);
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

  getCustomers(){
    this.apiServiceGET.getCustomers().subscribe(
      res => {
        this.customerArray = res;
      },
      err => {
        alert("Ha habido un error")
      }
      
    );
  }
  submit(){
    if(!this.registerForm.valid){
      alert("ERROR");
      return;
    }
    else{
      console.log(this.registerForm.value)
      this.apiService.addBag(this.registerForm.value).subscribe(
        res => {
          console.log(res);
        }
      );
      if(this.bags.length != 0){
        for(let i = 0; i < this.bags.length; i++){
          if(i == 0){
            this.bags.at(i).get('price')?.setValue(25);
          }
          else{
            this.bags.at(i).get('price')?.setValue(75);
          }
        }
        this.apiService.addBag(this.bags.value).subscribe(
          res => {
            console.log(res);
          }
        );
      }

      
      
    }
  }

}
