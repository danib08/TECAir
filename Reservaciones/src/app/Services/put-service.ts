import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CustomerModel } from "../Pages/models/customer";
import { UserInFlightModel } from "../Pages/models/user-in-flight-model";

@Injectable({
    providedIn: 'root'
})
export class PutService {
    private baseURL = "http://localhost/api";
    private setCustomerInFlightURL = this.baseURL+'/CustomersInFlights/';
    private updateCustomerURL = this.baseURL+'/Customers';

    /**
     * Método constructor
     * @param http 
     */
     constructor(private http: HttpClient) {

    }
    /**
     * Set a seat for the customer
     * @param customer 
     * @param flightID 
     * @param customerID 
     * @returns 
     */
    setSeat(customer: UserInFlightModel, flightID:string, customerID:string){
        let URL = this.setCustomerInFlightURL+customerID+'/'+flightID;
        return this.http.put<any>(URL, customer);
    }

    /**
     * update a customer into the db
     * @param customer 
     * @returns 
     */
     updateCustomer(customer: CustomerModel):Observable<any>{
         let URL = this.updateCustomerURL+'/'+customer.customerid;
        return this.http.put<any>(URL, customer);
    }
}
