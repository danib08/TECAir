import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { UserInFlightModel } from "../Pages/models/user-in-flight-model";

@Injectable({
    providedIn: 'root'
})
export class PutService {
    private baseURL = "https://localhost:5001/api";
    private changeStatusURL = this.baseURL+'/Flights/Status/';
    private setDiscountURL = this.baseURL+'/Flights/Discount/';
    private setCustomerInFlightURL = this.baseURL+'/CustomersInFlights/';
    /**
     * Método constructor
     * @param http 
     */
     constructor(private http: HttpClient) {

    }

    changeStatus(status: FormControl, flightID:string):Observable<any>{
        let URL = this.changeStatusURL+flightID;
        return this.http.put<any>(URL, status);
    }
    addDiscount(discount: FormControl, flightID:string):Observable<any>{
        let URL = this.setDiscountURL+flightID;
        return this.http.put<any>(URL, discount);
    }
    setSeat(customer: UserInFlightModel, flightID:string, customerID:string){
        let URL = this.setCustomerInFlightURL+customerID+'/'+flightID;
        return this.http.put<any>(URL, customer);
    }
}
