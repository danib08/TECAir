import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { PostService } from 'src/app/Services/post-service';
import { CustomerModel } from '../../models/customer';

@Component({
  selector: 'app-validacion-usuario-flight',
  templateUrl: './validacion-usuario-flight.component.html',
  styleUrls: ['./validacion-usuario-flight.component.css']
})
export class ValidacionUsuarioFlightComponent implements OnInit {

  User: CustomerModel = {
    namecustomer: '',
    lastnamecustomer: '',
    customerid: 0,
    passcustomer: '',
    email: '',
    phone: 0,
    studentid: 0,
    university: '',
    miles: 0
  }

  validation = {
    Existe: ''
  }
  /**
   * Constructor method
   * @param router 
   * @param apiService 
   * @param cookieSvc 
   */
   constructor(private router:Router,private apiService: PostService,private cookieSvc:CookieService) { }

  ngOnInit(): void {
  }
  /**
   * Validate if the customer exists 
   */
   validateUser(){
    this.apiService.validateUser(this.User).subscribe(
      res => {
        this.validation = res;
        if(this.validation.Existe == "Si"){
          this.cookieSvc.set('CustomerID', this.User.customerid.toString());
          this.cookieSvc.set('CustomerName', this.User.namecustomer);
          this.cookieSvc.set('CustomerLN', this.User.lastnamecustomer);
            this.router.navigate(["seatAssign"]);
        }else{
          alert("El usuario ingresado no existe")
        }
      }
    );
  }

}
