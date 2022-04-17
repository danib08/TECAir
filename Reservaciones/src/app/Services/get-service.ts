import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import { Flight } from '../Pages/models/flight';
import { BuscarVuelo } from '../Pages/models/buscar-vuelo';

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
  getVuelos(vuelo:BuscarVuelo):Observable<any>{
    return this.http.get<any>(this.addWorkerURL, {
      params: {
        Origin: vuelo.Origin,
        Destination: vuelo.Destination
      },
      observe: 'response'
    });
  }
  /**
     * @description Method for getting all the flights that have discounts
     * @returns Flight[]
     */
  getPromociones():Observable<Flight[]>{
    return this.http.get<Flight[]>(this.addWorkerURL);
  }
}
