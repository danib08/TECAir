import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { PostService } from 'src/app/Services/post-service';

@Component({
  selector: 'app-sign-up-workers',
  templateUrl: './sign-up-workers.component.html',
  styleUrls: ['./sign-up-workers.component.css']
})
export class SignUpWorkersComponent implements OnInit {

  /**
   * Constructor method
   * @param formBuilder 
   * @param apiService 
   */
  constructor(private formBuilder: FormBuilder, private apiService: PostService) { }

   /**
   * Method to be executed at component startup
   */
  ngOnInit(): void {
  }

  /**
   * get the workerid from the registerForm
   */
  get workerID(){
    return this.registerForm.get('workerid');
  }
  /**
   * get the nameWorker from the registerForm
   */
  get nameWorker(){
    return this.registerForm.get('nameworker');
  }
  /**
   * get the lastNameWorker from the registerForm
   */
  get lastNameWorker(){
    return this.registerForm.get('lastnameworker');
  }
  /**
   * get the password from the registerForm
   */
  get passWorker(){
    return this.registerForm.get('passworker');
  }
  /**
   * get the workers formArray
   */
  get workers(){
    return this.registerForm2.get('Workers') as FormArray;
  }
  registerForm = this.formBuilder.group({
    workerid: [0, Validators.required],
    nameworker: ['', Validators.required],
    lastnameworker: ['', Validators.required],
    passworker: ['',Validators.required],
  });

  registerForm2 = this.formBuilder.group({
    Workers:this.formBuilder.array([])
  });

  /**
   * Add a worker to the formArray
   */
  addWorkers(){
    const workersFormGroup = this.formBuilder.group({
      workerid: 0,
      nameworker: '',
      lastnameworker: '',
      passworker: ''
    });
    this.workers.push(workersFormGroup);
  }

  /**
   * Delete a worker from the formArray
   * @param index 
   */
  removeWorkers(index : number){
    this.workers.removeAt(index);
  }

  /**
   * Send the workers to the db
   * @returns 
   */
  submit(){
    let flag = false;
    if(this.workers.length != 0){
      flag = true;
    }
    if(!this.registerForm.valid){
      alert("ERROR");
      return;
    }
    else{
      console.log(this.registerForm.value)
      this.apiService.addWorker(this.registerForm.value).subscribe(
        res => {
          if(flag == false){
            location.reload()
          }
          console.log(res);
        }, err=>{
          alert("Ha ocurrido un error")
        }
      );
      if(this.workers.length != 0){
        for (let i = 0; i< this.workers.length; i++){
          this.apiService.addWorker(this.workers.at(i).value).subscribe(
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
