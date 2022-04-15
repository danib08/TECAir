import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FlightPriceModel } from "../Pages/models/flight-price";
import { FlightModel } from "../Pages/models/flight.model";


@Injectable({
    providedIn: 'root'
})
export class GetService {

    private baseURL = "https://jajaja.free.beeceptor.com";
    private getFlightsURL = `${this.baseURL}\\Flights`;
    constructor(private http: HttpClient) {

    }

    getFlights():Observable<FlightModel[]>{
        return this.http.get<FlightModel[]>(this.getFlightsURL);
    }

    getPrice(ID:string):Observable<FlightPriceModel>{
        let priceURL = `${this.baseURL}\\Flights\\`+ID;
        return this.http.get<FlightPriceModel>(priceURL);
    }
}
