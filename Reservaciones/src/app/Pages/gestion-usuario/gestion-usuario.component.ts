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
    Customerid: 0,
    Namecustomer: "",
    Lastnamecustomer: "",
    Passcustomer: "",
    Email: "",
    Phone: 0,
    Studentid: 0,
    University: "",
  }
  ngOnInit(): void {
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
