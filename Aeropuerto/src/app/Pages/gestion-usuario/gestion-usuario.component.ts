import { Component, OnInit } from '@angular/core';
import { CustomerModel } from '../models/customer';
import { PostService } from 'src/app/Services/post-service';

@Component({
  selector: 'app-gestion-usuario',
  templateUrl: './gestion-usuario.component.html',
  styleUrls: ['./gestion-usuario.component.css']
})
export class GestionUsuarioComponent implements OnInit {

  constructor(private apiService: PostService){}
    newUser: CustomerModel={
    CustomerID: 0,
    NameCustomer: "",
    LastNameCustomer: "",
    PassCustomer: "",
    Email: "",
    Phone: 0,
    StudentID: 0,
    University: "",
    Miles: 0
  }
  ngOnInit(): void {
  }
  /**
   * @description: Method for adding new users to the DB
   */
   SignUpUser(){
    this.apiService.addCustomer(this.newUser).subscribe(
      res =>{
        location.reload();
      }
    );
  }
}
