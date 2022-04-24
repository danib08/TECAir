import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { GetService } from 'src/app/Services/get-service';
import { PostService } from 'src/app/Services/post-service';
import { CustomerModel } from '../models/customer';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  customer: CustomerModel={
    customerid: 0,
    passcustomer: '',
    namecustomer: '',
    lastnamecustomer: '',
    email: '',
    phone: 0,
    studentid: 0,
    university: '',
    miles: 0
  }
  validation = {
    Existe: ""
  }
  constructor(private router:Router,private cookieSvc:CookieService,private apiService: PostService, private getSvc: GetService) { }

  ngOnInit(): void {}

  /**
   * @description: Method for login users to the web app
   */
  loginUser(){
    this.apiService.logInCustomer(this.customer).subscribe(
      res =>{
        this.validation = res;
        console.log(res);
        if (this.validation.Existe == "Si"){
          this.cookieSvc.set('CustomerID', this.customer.customerid.toString());
          this.setCustomer();
          this.router.navigate(["home"]);
        }else{
          alert("Contraseña o ID incorrectos")
        }
      },err =>{
        console.log(err)
      }
    );
  }
  /**
   * @description: Method for adding new users to the DB
   */
  SignUpUser(){
    this.apiService.addCustomer(this.customer).subscribe(
      res =>{
        location.reload();
      }, err => {
        alert("Ha ocurrido un error")
      }
    );
  }

  setCustomer(){
    this.getSvc.getCustomer(this.customer.customerid).subscribe(
      res =>{
        this.cookieSvc.set('CustomerName', res.namecustomer);
        this.cookieSvc.set('CustomerLN', res.lastnamecustomer);
      }, err =>{
        alert("Ha ocurrido un error")
      }
    );
  }
}
