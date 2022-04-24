import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { PostService } from 'src/app/Services/post-service';
import { CookieService } from 'ngx-cookie-service';
import { PlaneModel } from '../../models/plane-model';
import { GetService } from 'src/app/Services/get-service';


@Component({
  selector: 'app-crear-vuelo',
  templateUrl: './crear-vuelo.component.html',
  styleUrls: ['./crear-vuelo.component.css']
})
export class CrearVueloComponent implements OnInit {

  /**
   * Constructor method
   * @param formBuilder 
   * @param apiService 
   * @param cookieSvc 
   * @param apiServiceGET 
   */
  constructor(private formBuilder: FormBuilder, private apiService: PostService, private cookieSvc:CookieService, private apiServiceGET: GetService) { }
 

  list: Array<string> = [];
  planesArray: PlaneModel[] = [];
  /**
   * Method to be executed at component startup
   */
  ngOnInit(): void {
    this.getPlanes();
  }

  /**
   * get the origin data from the registerForm
   */
  get origin(){
    return this.registerForm.get('origin');
  }
  /**
   * get the destination data from the registerForm
   */
  get destination(){
    return this.registerForm.get('destination');
  }
  /**
   * get the bagquantity data from the registerForm
   */
  get bagQuantity(){
    return this.registerForm.get('bagquantity');
  }
  /**
   * get the userquantity data from the registerForm
   */
  get userQuantity(){
    return this.registerForm.get('userquantity');
  }
  /**
   * get the flightid data from the registerForm
   */
  get flightID(){
    return this.registerForm.get('flightid');
  }
  /**
   * get the departuretime data from the registerForm
   */
  get departureTime(){
    return this.registerForm.get('departure');
  }
  /**
   * get the arrivaltime data from the registerForm
   */
  get arrivalTime(){
    return this.registerForm.get('arrival');
  }
  /**
   * get the stops data from the registerForm
   */
  get stops(){
    return this.registerForm2.get('Stops') as FormArray;
  }
  /**
   * get the price data from the registerForm
   */
  get price(){
    return this.registerForm.get('price');
  }
  /**
   * get the gate data from the registerForm
   */
  get gate(){
    return this.registerForm.get('gate');
  }

  registerForm = this.formBuilder.group({
    origin: ['', Validators.required],
    destination: ['', Validators.required],
    flightid: ['', Validators.required],
    departure: ['',Validators.required],
    arrival:['', Validators.required],
    stops:[[]],
    workerid: parseInt(this.cookieSvc.get('Workerid')),
    planeid: ['', Validators.required],
    bagquantity: 0,
    userquantity: 0,
    price: [0, Validators.required],
    gate: [0, Validators.required],
    status: 'Scheduled',
    discount: 0
  });

  registerForm2 = this.formBuilder.group({
    Stops:this.formBuilder.array([])
  });

  /**
   * Add a stop into the formArray
   */
  addStops(){
    const stopsFormGroup = this.formBuilder.group({
      origin: '',
      destination: '',
      flightid: '',
      departure: '',
      arrival: '',
      workerid: parseInt(this.cookieSvc.get('Workerid')),
      planeid: '',
      bagquantity: 0,
      userquantity: 0,
      price: 0,
      stops: [],
      gate: 0,
      status: 'Scheduled',
      discount: 0
    });
    this.stops.push(stopsFormGroup);
  }
  /**
 * Delete the index stop from the formArray
 * @param index 
 */
  removeStops(index : number){
    this.stops.removeAt(index);
  }

  /**
   * Send the flights data to the api
   * @returns 
   */
  submit(){
    let flag = false;
    if(this.stops.length != 0){
      flag = true;
    }
    if(!this.registerForm.valid){
      alert("ERROR");
      return;
    }
    else{
      for(let i = 0; i < this.stops.length; i++){
        this.list.push(this.stops.at(i).get('flightid')?.value);
      }
      this.registerForm.get('stops')?.setValue(this.list);
      console.log(this.registerForm.value)
      this.apiService.addFlight(this.registerForm.value).subscribe(
        res => {
          if(flag == false){
            location.reload()
          }
        },err => {
          alert("Ha ocurrido un error")
        }
      );
      if(this.stops.length != 0){
        for (let i = 0; i < this.stops.length; i++){
          this.apiService.addFlight(this.stops.at(i).value).subscribe(
            res => {
              console.log(res);
            },err=>{
              alert("Ha ocurrido un error")
            }
          );
          location.reload();
        }
        
      }
    }
  }

  /**
   * get the planes data from the api
   */
  getPlanes(){
    this.apiServiceGET.getPlanes().subscribe(
      res => {
        this.planesArray = res;
      },
      err => {
        alert("Ha habido un error")
      }
      
    );
  }
  
}

