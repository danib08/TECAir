import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CustomerModel } from "../Pages/models/customer";
import { FlightCapModel } from "../Pages/models/flight-cap-model";
import { FlightPriceModel } from "../Pages/models/flight-price";
import { FlightModel } from "../Pages/models/flight.model";
import { PlaneModel } from "../Pages/models/plane-model";
import { UserInFlightModel } from "../Pages/models/user-in-flight-model";


@Injectable({
    providedIn: 'root'
})
export class GetService {

    private baseURL = "https://localhost:5001/api";
    private getFlightsURL = this.baseURL+'/Flights';
    private getCustomerURL = this.baseURL+'/Customers';
    private getCustomerFlightURL = this.baseURL+'/CustomersInFlights/';
    private getFlightCapURL = this.baseURL+'/Flights/Capacity/';
    private getPlaneURL = this.baseURL+'/Planes';
    private getDiscountsURL = this.baseURL+'/Flights/Discount';
    
    constructor(private http: HttpClient) {

    }

    getFlights():Observable<FlightModel[]>{
        return this.http.get<FlightModel[]>(this.getFlightsURL);
    }

    getPrice(ID:string):Observable<FlightPriceModel>{
        let priceURL = `${this.baseURL}\\Flights/Price\\`+ID;
        return this.http.get<FlightPriceModel>(priceURL);
    }

    getCustomers():Observable<CustomerModel[]>{
        return this.http.get<CustomerModel[]>(this.getCustomerURL);
    }
    
    getPlanes():Observable<PlaneModel[]>{
        return this.http.get<PlaneModel[]>(this.getPlaneURL);
    }

    getCustomerInFlight(flight:string):Observable<UserInFlightModel[]>{
        let URL = this.getCustomerFlightURL + flight;
        return this.http.get<UserInFlightModel[]>(URL);
    }

    getFlightCapacity(flight:string):Observable<FlightCapModel>{
        let URL = this.getFlightCapURL + flight;
        return this.http.get<FlightCapModel>(URL);
    }

    getFlight(flight: string):Observable<FlightModel>{
        let URL = `${this.baseURL}\\Flights\\`+flight;
        return this.http.get<FlightModel>(URL);
    }

    getDiscounts():Observable<FlightModel[]>{
        return this.http.get<FlightModel[]>(this.getDiscountsURL);
    }
}
