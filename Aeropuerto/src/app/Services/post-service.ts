import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class PostService {
    private baseURL = "http://localhost..."
    private addWorkerURL = "https://prueba.free.beeceptor.com"

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
}
