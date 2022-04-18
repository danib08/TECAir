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

  constructor(private formBuilder: FormBuilder, private apiService: PostService, private cookieSvc:CookieService, private apiServiceGET: GetService) { }
 

  list: Array<string> = [];
  planesArray: PlaneModel[] = [];

  ngOnInit(): void {
    this.getPlanes();
  }

  get origin(){
    return this.registerForm.get('Origin');
  }
  
  get destination(){
    return this.registerForm.get('Destination');
  }

  get bagQuantity(){
    return this.registerForm.get('BagQuantity');
  }

  get userQuantity(){
    return this.registerForm.get('UserQuantity');
  }

  get flightID(){
    return this.registerForm.get('FlightID');
  }

  get departureTime(){
    return this.registerForm.get('DepartureTime');
  }

  get arrivalTime(){
    return this.registerForm.get('ArrivalTime');
  }

  get stops(){
    return this.registerForm2.get('Stops') as FormArray;
  }

  registerForm = this.formBuilder.group({
    Origin: ['', Validators.required],
    Destination: ['', Validators.required],
    FlightID: ['', Validators.required],
    Departure: ['',Validators.required],
    Arrival:['', Validators.required],
    Stops:[[]],
    WorkerID: parseInt(this.cookieSvc.get('WorkerID')),
    PlaneID: ['', Validators.required]
    
  });

  registerForm2 = this.formBuilder.group({
    Stops:this.formBuilder.array([])
  });

  addStops(){
    const stopsFormGroup = this.formBuilder.group({
      Origin: '',
      Destination: '',
      FlightID: '',
      Departure: '',
      Arrival: '',
      WorkerID: parseInt(this.cookieSvc.get('WorkerID')),
      PlaneID: ''
    });
    this.stops.push(stopsFormGroup);
  }

  removeStops(index : number){
    this.stops.removeAt(index);
  }

  submit(){
    if(!this.registerForm.valid){
      alert("ERROR");
      return;
    }
    else{
      for(let i = 0; i < this.stops.length; i++){
        this.list.push(this.stops.at(i).get('FlightID')?.value);
      }
      this.registerForm.get('Stops')?.setValue(this.list);
      this.apiService.addFlight(this.registerForm.value).subscribe(
        res => {
          console.log(res);
          location.reload();
        }
      );
      if(this.stops.length != 0){
        this.apiService.addFlight(this.stops.value).subscribe(
          res => {
            console.log(res);
            location.reload();
          }
        );
      }
    }
  }
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

