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

  /***
   * Constructor method
   */
  constructor(private formBuilder: FormBuilder, private apiServiceGET:GetService, private apiService:PostService) { }

  /**
   * Method to be executed at component startup
   */
  ngOnInit(): void {
    this.getFlights();
    this.getCustomers();
  }

  /**
   * Get the customerid from the formgroup
   */
  get customerID(){
    return this.registerForm.get('customerid');
  }

   /**
   * Get the flightid from the formgroup
   */
  get flightID(){
    return this.registerForm.get('flightid');
  }

 /**
   * Get the weight from the formgroup
   */
  get weight(){
    return this.registerForm.get('weight');
  }

   /**
   * Get the color from the formgroup
   */
  get color(){
    return this.registerForm.get('color');
  }

   /**
   * Get the bagid from the formgroup
   */
  get bagid(){
    return this.registerForm.get('bagid');
  }
  
 /**
   * Get the extra bags as an array
   */
  get bags(){
    return this.registerForm2.get('Bags') as FormArray;
  }

  registerForm = this.formBuilder.group({
    customerid: [0, Validators.required],
    weight: [0, Validators.required],
    flightid: ['',Validators.required],
    color:['', Validators.required],
    bagid:['', Validators.required],
    price: 0
  });

  registerForm2 = this.formBuilder.group({
    Bags:this.formBuilder.array([])
  });

  /**
   * Add the extra bags to an array
   */
  addBags(){
    const bagsFormGroup = this.formBuilder.group({
      customerid: this.customerID?.value,
      weight: 0,
      flightid: this.flightID?.value,
      color:'',
      bagid:'',
      price: 0

    });
    this.bags.push(bagsFormGroup);
  }

  /**
   * Delete an extra bag from the array
   * @param index 
   */
  removeBags(index : number){
    this.bags.removeAt(index);
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
   * Http Get call for all the customers in flight
   */
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

  /**
   * Http Post to add all the customer bags
   * @returns 
   */
  submit(){
    let flag = false;
    if(this.bags.length != 0){
      flag = true;
    }
    if(!this.registerForm.valid){
      alert("ERROR");
      return;
    }
    else{
      console.log(this.registerForm.value)
      this.apiService.addBag(this.registerForm.value).subscribe(
        res => {
          if(flag == false){
            location.reload()
          }
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
        if(this.bags.length != 0){
          for (let i = 0; i < this.bags.length; i++){
            this.apiService.addBag(this.bags.at(i).value).subscribe(
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
  }

}
