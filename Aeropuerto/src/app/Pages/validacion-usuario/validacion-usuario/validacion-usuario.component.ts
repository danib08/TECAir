import { Component, OnInit } from '@angular/core';
import { PostService } from 'src/app/Services/post-service';
import { UserValModel } from '../../models/user-val-model';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-validacion-usuario',
  templateUrl: './validacion-usuario.component.html',
  styleUrls: ['./validacion-usuario.component.css']
})

export class ValidacionUsuarioComponent implements OnInit {

  User: UserValModel = {
    namecustomer: '',
    lastnamecustomer: '',
    customerid: 0
  }

  validation = {
    Existe: ""
  }

  constructor(private router:Router,private apiService: PostService,private cookieSvc:CookieService) { }

  ngOnInit(): void {
  }

  validateUser(){
    this.apiService.validateUser(this.User).subscribe(
      res => {
        this.validation = res;
        if(this.validation.Existe == "Si"){
          this.cookieSvc.set('CustomerID', this.User.customerid.toString());
          this.cookieSvc.set('CustomerName', this.User.namecustomer);
          this.cookieSvc.set('CustomerLN', this.User.lastnamecustomer);
          this.router.navigate(["busquedaVuelo"]);
        }else{
          alert("El usuario ingresado no existe")
        }
      }
    );
  }

}
