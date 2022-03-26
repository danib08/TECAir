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
  loginUser(event: { preventDefault: () => void; target: any; }){

    event.preventDefault()
    const target= event.target
    const username= target.querySelector("#username").value
    const password= target.querySelector("#password").value

    if (username=="daval" && password=="123"){
      //window.alert("Hola mundo")
      this.router.navigate(["home"])
    }
    else{
      //window.alert("XD")
    }
    console.log(username,password)
  }

}
