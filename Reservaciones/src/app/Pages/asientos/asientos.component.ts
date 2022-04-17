import { ArrayType } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-asientos',
  templateUrl: './asientos.component.html',
  styleUrls: ['./asientos.component.css']
})
export class AsientosComponent implements OnInit {

  constructor(private cookieSvc:CookieService,private router:Router) {
    this.hacerMatrix();
    console.log(this.arr_name);
  }
  array = [1,5,9,14];
  numAsientos = 200;
  arr_name:number[][]=[[]];
  cont=0;

  getNumber(number:Number){
    this.cookieSvc.set("numAsiento", number.toString());
  }
  checkPago(){
    this.router.navigate(["reservacionVuelo"]);
  }
  hacerMatrix(){
    this.arr_name = [];
    for(var i: number = 0; i < this.numAsientos/10; i++) {
        this.arr_name[i] = [];
        for(var j: number = 0; j< 10; j++) {
          this.arr_name[i][j]=this.cont;
          this.cont+=1;
        }
    }
  }
  verdad(valor:number){
    if (this.array.includes(valor)){
      return true;
    }else{
      return false;
    }
  }

  ngOnInit(): void {}

}
