import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-crear-vuelo',
  templateUrl: './crear-vuelo.component.html',
  styleUrls: ['./crear-vuelo.component.css']
})
export class CrearVueloComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }
 

  list: Array<string> = [];


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
    DepartureTime: ['',Validators.required],
    ArrivalTime:['', Validators.required],
    Stops:[[]]
    
  });

  registerForm2 = this.formBuilder.group({
    Stops:this.formBuilder.array([])
  });


  ngOnInit(): void {
  }

  addStops(){
    const stopsFormGroup = this.formBuilder.group({
      Origin: '',
      Destination: '',
      FlightID: '',
      DepartureTime: '',
      ArrivalTime: ''
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
      console.log(this.registerForm.value);
      console.log(this.registerForm2.value);
      console.log(this.list);
    }
  }


  refresh(){
    this.registerForm.patchValue({
      Origin: '',
      Destination: '',
      BagQuantity: 0,
      UserQuantity: 0,
      FlightID: '',
      DepartureTime: '',
      ArrivalTime:''
    });
    this.stops.controls.splice(0, this.stops.length);
  }
  
  
}
function foreach(each: any, arg1: boolean) {
  throw new Error('Function not implemented.');
}

