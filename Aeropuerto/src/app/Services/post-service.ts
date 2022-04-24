import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { CustomerModel } from "../Pages/models/customer";
import { FlightSearchModel } from "../Pages/models/flight-search-model";
import { FlightModel } from "../Pages/models/flight.model";
import { LoginModelW } from "../Pages/models/login-model-w";
import { UserInFlightModel } from "../Pages/models/user-in-flight-model";
import { UserValModel } from "../Pages/models/user-val-model";
import { WorkerModel } from "../Pages/models/worker-model";

@Injectable({
    providedIn: 'root'
})
export class PostService {
    private baseURL = "http://localhost/api";
    private addWorkerURL = this.baseURL+'/Workers/Worker';
    private addFlightURL = this.baseURL+'/Flights/Flight';
    private addCustomerURL = this.baseURL+'/Customers';
    private addBagURL = this.baseURL+'/Bags/Bag';
    private searchURL = this.baseURL+'/Flights/SearchFlight';
    private logInWURL = this.baseURL+'/Workers/LogIn';
    private validateUserURL = this.baseURL+'/Customers/Validate';
    private addCustomerInFlightURL = this.baseURL+'/CustomersInFlights';
    private searchCustomersSeatsURL = this.baseURL+'/CustomersInFlights/NoSeats';

    /**
     * Método constructor
     * @param http 
     */
     constructor(private http: HttpClient) {

    }

    /**
     * Add a new worker to the db
     * @param worker 
     * @returns 
     */
    addWorker(worker: FormControl):Observable<any>{
        return this.http.post<any>(this.addWorkerURL, worker);
    }
   
    /**
     * add a flight to the db
     * @param flight 
     * @returns 
     */
    addFlight(flight: FormControl):Observable<any>{
        return this.http.post<any>(this.addFlightURL, flight);
    }

    /**
     * add a bag to the db
     * @param bag 
     * @returns 
     */
    addBag(bag: FormControl):Observable<any>{
        return this.http.post<any>(this.addBagURL, bag);
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
     * @param worker 
     * @returns 
     */
    logInWorker(worker: WorkerModel):Observable<any>{
        return this.http.post<any>(this.logInWURL, worker);
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
     * Validate if a customer exists in the db
     * @param customer 
     * @returns 
     */
    validateUser(customer: UserValModel):Observable<any>{
        return this.http.post<any>(this.validateUserURL, customer);
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
