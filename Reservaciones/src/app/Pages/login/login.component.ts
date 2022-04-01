import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  //Here we make the conection with the REST/API
  /**
   * @description: Method for login users to the web app
   */
  loginUser(event: { preventDefault: () => void; target: any; }){
    event.preventDefault()
    const target= event.target
    console.log("Hola mundo")
  }
  //Here we make the conection with the REST/API
  /**
   * @description: Method for adding new users to the DB
   */
  SignUpUser(event: { preventDefault: () => void; target: any; }){
    event.preventDefault()
    const target= event.target
    console.log("Hola mundo 2")
  }

}
