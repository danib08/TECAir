import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CustomerModel } from "../Pages/models/customer";
import { FlightPriceModel } from "../Pages/models/flight-price";
import { FlightModel } from "../Pages/models/flight.model";
import { PlaneModel } from "../Pages/models/plane-model";


@Injectable({
    providedIn: 'root'
})
export class GetService {

    private baseURL = "https://prueba.free.beeceptor.com";
    private getFlightsURL = `${this.baseURL}\\Flights`;
    private getCustomerURL = `${this.baseURL}\\Customers`;
    private getPlaneURL = `${this.baseURL}\\Planes`;
    constructor(private http: HttpClient) {

    }

    getFlights():Observable<FlightModel[]>{
        return this.http.get<FlightModel[]>(this.getFlightsURL);
    }

    getPrice(ID:string):Observable<FlightPriceModel>{
        let priceURL = `${this.baseURL}\\Flights\\`+ID;
        return this.http.get<FlightPriceModel>(priceURL);
    }
    getCustomers():Observable<CustomerModel[]>{
        return this.http.get<CustomerModel[]>(this.getCustomerURL);
    }
    getPlanes():Observable<PlaneModel[]>{
        return this.http.get<PlaneModel[]>(this.getPlaneURL);
    }
}
