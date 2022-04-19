import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class PatchService {

    private baseURL = "https://localhost:5001/api";
    private changeStatusURL = `${this.baseURL}\\Flights/FlightStatus`;
    private setDiscountURL = `${this.baseURL}\\Flights/FlightDiscount`;
    /**
     * Método constructor
     * @param http 
     */
     constructor(private http: HttpClient) {

    }

    changeStatus(status: FormControl):Observable<any>{
        return this.http.patch<any>(this.changeStatusURL, status);
    }
    addDiscount(discount: FormControl):Observable<any>{
        return this.http.patch<any>(this.setDiscountURL, discount);
    }
}