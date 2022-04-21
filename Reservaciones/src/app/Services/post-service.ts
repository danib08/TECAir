import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { Flight } from "../Pages/models/flight";
import { Customer } from "../Pages/models/customer";
import { IniciarSesion } from "../Pages/models/iniciar-sesion";

@Injectable({
    providedIn: 'root'
})
export class PostService {
  //private baseURL = "http://localhost..."
  private baseURL = "https://localhost:5001/api";
  private addWorkerURL = "https://tecair.free.beeceptor.com"
  private addCustomerURL = `${this.baseURL}\\Customers`;
  private logInUser = `${this.baseURL}\\Customers/validate`;
  private searchURL = `${this.baseURL}\\Flights`;

  /**
   * * Método constructor
    * @param http
  */
  constructor(private http: HttpClient) {}
  /**
    * @description Method for register a user
    * @param Customer
    * @returns EstadoModel Object
    */
  addCustomer(Usuarios: Customer):Observable<any>{
    return this.http.post<any>(this.addCustomerURL, Usuarios);
  }
  /**
    * @description Method for login a user
    * @param Customer
    * @returns EstadoModel Object
  */
  logInUsuario(Usuarios: IniciarSesion):Observable<any>{
    return this.http.post<any>(this.logInUser, Usuarios);
  }
  /**
    * @description Method for search flights
    * @param Customer
    * @returns EstadoModel Object
  */
  searchFlights(search: Flight):Observable<any>{
    return this.http.post<any>(this.searchURL, search);
  }
}
