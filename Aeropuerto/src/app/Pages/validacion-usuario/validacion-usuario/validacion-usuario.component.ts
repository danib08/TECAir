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
    NameCustomer: '',
    LastNameCustomer: '',
    CustomerID: 0
  }
  constructor(private router:Router,private apiService: PostService,private cookieSvc:CookieService) { }

  ngOnInit(): void {
  }

  validateUser(){
    this.apiService.validateUser(this.User).subscribe(
      res => {
        this.cookieSvc.set('CustomerID', this.User.CustomerID.toString());
        this.router.navigate(["busquedaVuelo"]);
      },
      err =>{
        alert("Entrada incorrecta")
      }
    );
  }

}
