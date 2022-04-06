import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up-workers',
  templateUrl: './sign-up-workers.component.html',
  styleUrls: ['./sign-up-workers.component.css']
})
export class SignUpWorkersComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  get workerID(){
    return this.registerForm.get('WorkerID');
  }
  get nameWorker(){
    return this.registerForm.get('NameWorker');
  }
  get lastNameWorker(){
    return this.registerForm.get('LastNameWorker');
  }
  get passWorker(){
    return this.registerForm.get('PassWorker');
  }
  get workers(){
    return this.registerForm2.get('Workers') as FormArray;
  }
  registerForm = this.formBuilder.group({
    WorkerID: ['', Validators.required],
    NameWorker: ['', Validators.required],
    LastNameWorker: ['', Validators.required],
    PassWorker: ['',Validators.required],
  });

  registerForm2 = this.formBuilder.group({
    Workers:this.formBuilder.array([])
  });

  addWorkers(){
    const workersFormGroup = this.formBuilder.group({
      WorkerID: '',
      NameWorker: '',
      LastNameWorker: '',
      PassWorker: ''
    });
    this.workers.push(workersFormGroup);
  }

  removeWorkers(index : number){
    this.workers.removeAt(index);
  }

  submit(){
    if(!this.registerForm.valid){
      alert("ERROR");
      return;
    }
    else{;
      console.log(this.registerForm.value);
      console.log(this.registerForm2.value);
    }
  }
}
