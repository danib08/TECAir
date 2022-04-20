import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { CustomerModel } from "../Pages/models/customer";
import { FlightSearchModel } from "../Pages/models/flight-search-model";
import { FlightModel } from "../Pages/models/flight.model";
import { LoginModelW } from "../Pages/models/login-model-w";
import { UserValModel } from "../Pages/models/user-val-model";
import { WorkerModel } from "../Pages/models/worker-model";

@Injectable({
    providedIn: 'root'
})
export class PostService {
    private baseURL = "https://localhost:5001/api";
    private addWorkerURL = `${this.baseURL}\\Workers/Worker`;
    private addFlightURL = `${this.baseURL}\\Flights/Flight`;
    private addCustomerURL = `${this.baseURL}\\Customers`;
    private addBagURL = `${this.baseURL}\\Bags/Bag`;
    private searchURL = `${this.baseURL}\\Flights`;
    private logInWURL = `${this.baseURL}\\Workers/LogIn`;
    private validateUserURL = `${this.baseURL}\\Customers/Validate`;

    /**
     * Método constructor
     * @param http 
     */
     constructor(private http: HttpClient) {

    }

    addWorker(worker: FormControl):Observable<any>{
        return this.http.post<any>(this.addWorkerURL, worker);
    }
    
    addFlight(flight: FormControl):Observable<any>{
        return this.http.post<any>(this.addFlightURL, flight);
    }

    addBag(bag: FormControl):Observable<any>{
        return this.http.post<any>(this.addBagURL, bag);
    }

    searchFlights(search: FlightModel):Observable<any>{
        return this.http.post<any>(this.searchURL, search);
    }

    logInWorker(worker: WorkerModel):Observable<any>{
        return this.http.post<any>(this.logInWURL, worker);
    }

    addCustomer(customer: CustomerModel):Observable<any>{
        return this.http.post<any>(this.addCustomerURL, customer);
    }

    validateUser(customer: UserValModel):Observable<any>{
        return this.http.post<any>(this.validateUserURL, customer);
    }
}
