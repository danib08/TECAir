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
    return this.registerForm.get('CustomerID');
  }

  get flightID(){
    return this.registerForm.get('FlightID');
  }

  get weight(){
    return this.registerForm.get('Weight');
  }

  get color(){
    return this.registerForm.get('Color');
  }

  get bags(){
    return this.registerForm2.get('Bags') as FormArray;
  }

  registerForm = this.formBuilder.group({
    CustomerID: ['', Validators.required],
    Weight: [0, Validators.required],
    FlightID: ['',Validators.required],
    Color:['', Validators.required],
    Price: 0
  });

  registerForm2 = this.formBuilder.group({
    Bags:this.formBuilder.array([])
  });

  addBags(){
    const bagsFormGroup = this.formBuilder.group({
      CustomerID: this.customerID?.value,
      Weight: 0,
      FlightID: this.flightID?.value,
      Color:'',
      Price: 0

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
      this.apiService.addBag(this.registerForm.value).subscribe(
        res => {
          console.log(res);
        }
      );
      if(this.bags.length != 0){
        for(let i = 0; i < this.bags.length; i++){
          if(i == 0){
            this.bags.at(i).get('Price')?.setValue(25);
          }
          else{
            this.bags.at(i).get('Price')?.setValue(75);
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
