import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gestion-usuario',
  templateUrl: './gestion-usuario.component.html',
  styleUrls: ['./gestion-usuario.component.css']
})
export class GestionUsuarioComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  /**
   * @description: Method for adding new users to the DB
   */
  SignUpUser(event: { preventDefault: () => void; target: any; }){
    event.preventDefault()
    const target= event.target
    console.log("Hola mundo 2")
  }
}
