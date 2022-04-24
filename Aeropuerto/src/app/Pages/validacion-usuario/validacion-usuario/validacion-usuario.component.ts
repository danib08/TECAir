import { Component, OnInit } from '@angular/core';
import { PostService } from 'src/app/Services/post-service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { CustomerModel } from '../../models/customer';

@Component({
  selector: 'app-validacion-usuario',
  templateUrl: './validacion-usuario.component.html',
  styleUrls: ['./validacion-usuario.component.css']
})

export class ValidacionUsuarioComponent implements OnInit {

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

   /**
   * Method to be executed at component startup
   */
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
          if(this.cookieSvc.get('FlightID')==''){
            this.router.navigate(["busquedaVuelo"]);
          }
          else{
            this.router.navigate(["pago"]);
          }
        }else{
          alert("El usuario ingresado no existe")
        }
      }
    );
  }

}
