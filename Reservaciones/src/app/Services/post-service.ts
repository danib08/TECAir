import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { Customer } from "../Pages/models/customer";
import { IniciarSesion } from "../Pages/models/iniciar-sesion";

@Injectable({
    providedIn: 'root'
})
export class PostService {
    private baseURL = "http://localhost..."
    private addWorkerURL = "https://tecair.free.beeceptor.com"

    /**
     * Método constructor
     * @param http
     */
     constructor(private http: HttpClient) {

    }
    /**
     * @description Method for register a user
     * @param Customer
     * @returns EstadoModel Object
     */
    addCustomer(Usuarios: Customer):Observable<any>{
      return this.http.post<any>(this.addWorkerURL, Usuarios);
    }
    /**
     * @description Method for login a user
     * @param Customer
     * @returns EstadoModel Object
     */
    login(Usuarios: IniciarSesion):Observable<any>{
      return this.http.post<any>(this.addWorkerURL, Usuarios);
    }

    addWorker(worker: FormControl):Observable<any>{
        return this.http.post<any>(this.addWorkerURL, worker);
    }

    addFlight(flight: FormControl):Observable<any>{
        return this.http.post<any>(this.addWorkerURL, flight);
    }
}
