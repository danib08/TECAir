import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { Flight } from '../Pages/models/flight';

@Injectable({
  providedIn: 'root'
})
export class GetService {
  private baseURL = "http://localhost..."
  private addWorkerURL = "https://tecair.free.beeceptor.com"

  /**
     * Método constructor
     * @param http
     */
  constructor(private http: HttpClient) {}

  /**
     * @description Method for getting all the available flights
     * @returns Flight[]
     */
  getVuelos():Observable<Flight[]>{
    return this.http.get<Flight[]>(this.addWorkerURL);
  }
  /**
     * @description Method for getting all the flights that have discounts
     * @returns Flight[]
     */
   getPromociones():Observable<Flight[]>{
    return this.http.get<Flight[]>(this.addWorkerURL);
  }
}
