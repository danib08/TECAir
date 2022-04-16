import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { PostService } from 'src/app/Services/post-service';
import { Customer } from '../models/customer';
import { EstadoModel } from '../models/estado-model';
import { IniciarSesion } from '../models/iniciar-sesion';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router:Router,private cookieSvc:CookieService,private apiService: PostService) { }
  nuevoUsuario: Customer={
    Customerid: 0,
    Namecustomer: "",
    Lastnamecustomer: "",
    Passcustomer: "",
    Email: "",
    Phone: 0,
    Studentid: 0,
    University: "",
  }

  usuarioRegistrado: IniciarSesion={
    Passcustomer: "",
    Email: ""
  }

  estadoRes: EstadoModel = {
    estado:""
  }
  ngOnInit(): void {}

  /**
   * @description: Method for login users to the web app
   */
  loginUser(){
    this.apiService.login(this.usuarioRegistrado).subscribe(
      res =>{
        this.estadoRes = res;
        if(this.estadoRes.estado == "OK"){
          window.alert("BIENVENIDO");
          this.router.navigate(["home"]);
        }else{
          window.alert("CONTRASEÑA O EMAILL INCORRECTOS")
        }
      }
    );
  }
  /**
   * @description: Method for adding new users to the DB
   */
  SignUpUser(){
    this.apiService.addCustomer(this.nuevoUsuario).subscribe(
      res =>{
        location.reload();
      }
    );
  }
}
