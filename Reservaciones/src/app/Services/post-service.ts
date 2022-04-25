import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CustomerModel } from "../Pages/models/customer";;
import { FlightModel } from "../Pages/models/flight.model";
import { UserInFlightModel } from "../Pages/models/user-in-flight-model";

@Injectable({
    providedIn: 'root'
})
export class PostService {
    private baseURL = "http://localhost/api";
    private addCustomerURL = this.baseURL+'/Customers';
    private searchURL = this.baseURL+'/Flights/SearchFlight';
    private logInWURL = this.baseURL+'/Customers/LogIn';
    private addCustomerInFlightURL = this.baseURL+'/CustomersInFlights';
    private searchCustomersSeatsURL = this.baseURL+'/CustomersInFlights/NoSeats';


    /**
     * Método constructor
     * @param http 
     */
     constructor(private http: HttpClient) {

    }
  

    /**
     * search a flight from the db
     * @param search 
     * @returns 
     */
    searchFlights(search: FlightModel):Observable<any>{
        return this.http.post<any>(this.searchURL, search);
    }

    /**
     * Validate the login worker with a http request
     * @param customer 
     * @returns 
     */
    logInCustomer(customer: CustomerModel):Observable<any>{
        return this.http.post<any>(this.logInWURL, customer);
    }

    /**
     * add a customer into the db
     * @param customer 
     * @returns 
     */
    addCustomer(customer: CustomerModel):Observable<any>{
        return this.http.post<any>(this.addCustomerURL, customer);
    }

    /**
     * add a customer in flight to the db
     * @param customer 
     * @returns 
     */
    addCustomerInFlight(customer:UserInFlightModel):Observable<any>{
        return this.http.post<any>(this.addCustomerInFlightURL, customer);
    }

    /**
     * search the customer seats
     * @param search 
     * @returns 
     */
     searchSeats(customer: UserInFlightModel):Observable<any>{
         console.log(customer)
        return this.http.post<any>(this.searchCustomersSeatsURL, customer);
    }
}
