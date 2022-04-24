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

    private baseURL = "http://localhost/api";
    private getFlightsURL = this.baseURL+'/Flights';
    private getCustomerURL = this.baseURL+'/Customers';
    private getCustomerFlightURL = this.baseURL+'/CustomersInFlights/';
    private getFlightCapURL = this.baseURL+'/Flights/Capacity/';
    private getPlaneURL = this.baseURL+'/Planes';
    private getDiscountsURL = this.baseURL+'/Flights/Discount';
    
    /**
     * Constructor method
     * @param http 
     */
    constructor(private http: HttpClient) {

    }

    /**
     * get all the flights from the db
     * @returns 
     */
    getFlights():Observable<FlightModel[]>{
        return this.http.get<FlightModel[]>(this.getFlightsURL);
    }

    /**
     * get a flight price from the db
     * @param ID 
     * @returns 
     */
    getPrice(ID:string):Observable<FlightPriceModel>{
        let priceURL = `${this.baseURL}\\Flights/Price\\`+ID;
        return this.http.get<FlightPriceModel>(priceURL);
    }

    /**
     * get all the customers from the db
     * @returns 
     */
    getCustomers():Observable<CustomerModel[]>{
        return this.http.get<CustomerModel[]>(this.getCustomerURL);
    }
    /**
     * get all the planes from the db
     * @returns 
     */
    getPlanes():Observable<PlaneModel[]>{
        return this.http.get<PlaneModel[]>(this.getPlaneURL);
    }

    /**
     * get all the customers in flight
     * @param flight 
     * @returns 
     */
    getCustomerInFlight(flight:string):Observable<UserInFlightModel[]>{
        let URL = this.getCustomerFlightURL + flight;
        return this.http.get<UserInFlightModel[]>(URL);
    }

    /**
     * get the customer capacity for a flight
     * @param flight 
     * @returns 
     */
    getFlightCapacity(flight:string):Observable<FlightCapModel>{
        let URL = this.getFlightCapURL + flight;
        return this.http.get<FlightCapModel>(URL);
    }

    /**
     * get a flight
     * @param flight 
     * @returns 
     */
    getFlight(flight: string):Observable<FlightModel>{
        let URL = `${this.baseURL}\\Flights\\`+flight;
        return this.http.get<FlightModel>(URL);
    }

    /**
     * get the flights with discounts from the db
     * @returns 
     */
    getDiscounts():Observable<FlightModel[]>{
        return this.http.get<FlightModel[]>(this.getDiscountsURL);
    }
}
