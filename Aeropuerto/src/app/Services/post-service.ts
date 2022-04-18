import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { CustomerModel } from "../Pages/models/customer";
import { FlightSearchModel } from "../Pages/models/flight-search-model";
import { UserValModel } from "../Pages/models/user-val-model";
import { WorkerModel } from "../Pages/models/worker-model";

@Injectable({
    providedIn: 'root'
})
export class PostService {
    private baseURL = "http://localhost..."
    private addWorkerURL = "https://pruebaa.free.beeceptor.com"

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
        return this.http.post<any>(this.addWorkerURL, flight);
    }

    addBag(bag: FormControl):Observable<any>{
        return this.http.post<any>(this.addWorkerURL, bag);
    }

    searchFlights(search: FlightSearchModel):Observable<any>{
        return this.http.post<any>(this.addWorkerURL, search);
    }

    logInWorker(worker: WorkerModel):Observable<any>{
        return this.http.post<any>(this.addWorkerURL, worker);
    }

    addCustomer(customer: CustomerModel):Observable<any>{
        return this.http.post<any>(this.addWorkerURL, customer);
    }

    validateUser(customer: UserValModel):Observable<any>{
        return this.http.post<any>(this.addWorkerURL, customer);
    }
}
