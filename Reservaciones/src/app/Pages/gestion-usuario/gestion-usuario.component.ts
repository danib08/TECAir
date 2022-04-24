import { Component, OnInit } from '@angular/core';
import { CustomerModel } from '../models/customer';
import { PostService } from 'src/app/Services/post-service';
import { CookieService } from 'ngx-cookie-service';
import { PutService } from 'src/app/Services/put-service';

@Component({
  selector: 'app-gestion-usuario',
  templateUrl: './gestion-usuario.component.html',
  styleUrls: ['./gestion-usuario.component.css']
})
export class GestionUsuarioComponent implements OnInit {

  /**
   * Constructor Method
   * @param apiService 
   */
  constructor(private apiService: PutService, private cookieSvc:CookieService){}
    newUser: CustomerModel={
    customerid: parseInt(this.cookieSvc.get('CustomerID')),
    namecustomer: "",
    lastnamecustomer: "",
    passcustomer: "",
    email: "",
    phone: 0,
    studentid: 0,
    university: "",
    miles: 0
  }
  /**
   * Method to be executed at component startup
   */
  ngOnInit(): void {
  }
  /**
   * @description: Method for adding new users to the DB
   */
   SignUpUser(){
    this.apiService.updateCustomer(this.newUser).subscribe(
      res =>{
        location.reload();
      }, err => {
        alert("Ha ocurrido un error")
      }
    );
  }
}
