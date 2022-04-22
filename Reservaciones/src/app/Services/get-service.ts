import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { Flight } from '../Pages/models/flight';
import { UserInFlightModel } from "../Pages/models/user-in-flight-model";
import { FlightCapModel } from "../Pages/models/flight-cap-model";

@Injectable({
  providedIn: 'root'
})
export class GetService {
  private baseURL = "https://localhost:5001/api";
  private addWorkerURL = "https://tecair.free.beeceptor.com"
  private getFlightsURL = `${this.baseURL}\\Flights`;
  private getCustomerFlightURL = `${this.baseURL}\\CustomersInFlights/`;
  private getFlightCapURL = `${this.baseURL}\\Flights/Capacity/`;

  /**
     * Método constructor
     * @param http
  */
  constructor(private http: HttpClient) {}

  /**
    * @description Method for getting all the available flights
    * @returns Flight[]
  */
  getFlights():Observable<Flight[]>{
    return this.http.get<Flight[]>(this.getFlightsURL);
  }
  /**
    * @description Method to get a client on a flight
    * @param String
    * @returns Flight[]
  */
  getCustomerInFlight(flight:string):Observable<UserInFlightModel[]>{
    let URL = this.getCustomerFlightURL + flight;
    return this.http.get<UserInFlightModel[]>(URL);
  }
  /**
    * @description Method to obtain the capacity of the passengers in a flight.
    * @param String
    * @returns Flight[]
  */
  getFlightCapacity(flight:string):Observable<FlightCapModel>{
    let URL = this.getFlightCapURL + flight;
    return this.http.get<FlightCapModel>(URL);
  }
  /**
    * @description Method for getting a specific flight
    * @param String
    * @returns Flight[]
  */
  getFlight(flight: string):Observable<Flight>{
    let URL = `${this.baseURL}\\Flights\\`+flight;
    return this.http.get<Flight>(URL);
  }
}
