import { Component, OnInit } from '@angular/core';
import { GetService } from 'src/app/Services/get-service';
import { Flight } from '../models/flight';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private apiService:GetService) { }

  //List with all the flights
  listaVuelos:Flight[]=[];

  ngOnInit(): void {
    //this.apiService.getPromociones().subscribe(
    //  res => {
    //    this.listaVuelos = res;
    //  },
    //  err => {
    //    alert("Ha habido un error")
    //  }
    //);
  }

}
