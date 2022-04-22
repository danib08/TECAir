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
    customerid: 0,
    namecustomer: "",
    lastnamecustomer: "",
    passcustomer: "",
    email: "",
    phone: 0,
    studentid: 0,
    university: "",
    miles: 0
  }

  usuarioRegistrado: IniciarSesion={
    Passcustomer: "",
    customerid: 0
  }

  estadoRes: EstadoModel = {
    estado:""
  }
  ngOnInit(): void {}

  /**
   * @description: Method for login users to the web app
   */
  loginUser(){
    console.log(this.usuarioRegistrado)
    this.apiService.logInUsuario(this.usuarioRegistrado).subscribe(
      res =>{
        this.estadoRes = res;
        console.log(res);
        if (this.estadoRes.estado == "Si"){
          this.cookieSvc.set('usuarioCorreo', this.usuarioRegistrado.customerid.toString());
          this.router.navigate(["home"]);
        }else{
          alert("Contraseña o Correo incorrectos")
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
    this.nuevoUsuario.university=this.nuevoUsuario.university.toUpperCase();
    this.apiService.addCustomer(this.nuevoUsuario).subscribe(
      res =>{
        location.reload();
      }, err => {
        alert("Ha ocurrido un error")
      }
    );
  }
}
