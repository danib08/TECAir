import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class PatchService {

    private baseURL = "http://localhost..."
    private changeFlighttStatus = "https://tecair.free.beeceptor.com"
    /**
     * Método constructor
     * @param http 
     */
     constructor(private http: HttpClient) {

    }

    changeStatus(status: FormControl):Observable<any>{
        return this.http.patch<any>(this.changeFlighttStatus, status);
    }
    addDiscount(discount: FormControl):Observable<any>{
        return this.http.patch<any>(this.changeFlighttStatus, discount);
    }
}