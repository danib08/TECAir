import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { PostService } from 'src/app/Services/post-service';
import { WorkerModel } from '../models/worker-model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  worker: WorkerModel = {
    WorkerID: 0,
    PassWorker: ''
}
  constructor(private router:Router,private cookieSvc:CookieService,private apiService: PostService) { }

  ngOnInit(): void {}

  //Here we make the conection with the REST/API
  /**
   * @description: Method for login users to the web app
   */
  loginUser(event: { preventDefault: () => void; target: any; }){
    event.preventDefault()
    const target= event.target
    const ID =  parseInt(target.querySelector("#id").value);
    const password =  target.querySelector("#password").value;
    this.worker.WorkerID = ID;
    this.worker.PassWorker = password;
    this.validateData();
  }
  
  validateData(){
    this.apiService.logInWorker(this.worker).subscribe(
      res =>{
        this.cookieSvc.set('WorkerID', this.worker.WorkerID.toString());
        this.router.navigate(["home"]);
      }, 
      err =>{
        alert("Contraseña o ID incorrectos")
      }
    );
  }

}
