import { Component, OnInit } from '@angular/core';
import { Customer } from '../models/customer';
import { PostService } from 'src/app/Services/post-service';

@Component({
  selector: 'app-gestion-usuario',
  templateUrl: './gestion-usuario.component.html',
  styleUrls: ['./gestion-usuario.component.css']
})
export class GestionUsuarioComponent implements OnInit {

  constructor(private apiService: PostService){}
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
  ngOnInit(): void {
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
