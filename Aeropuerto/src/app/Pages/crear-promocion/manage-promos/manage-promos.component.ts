import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-manage-promos',
  templateUrl: './manage-promos.component.html',
  styleUrls: ['./manage-promos.component.css']
})
export class ManagePromosComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  get discounts(){
    return this.registerForm2.get('Discounts') as FormArray;
  }

  get flightID(){
    return this.registerForm.get('FlightID');
  }

  get discount(){
    return this.registerForm.get('Discount');
  }

  registerForm = this.formBuilder.group({
    FlightID: [''],
    Discount: [0]
  });

  registerForm2 = this.formBuilder.group({
    Discounts: this.formBuilder.array([])
  });

  addDiscounts(){
    const discountsFormGroup = this.formBuilder.group({
      FlightID: '',
      Discount: 0
    });
    this.discounts.push(discountsFormGroup);

  }
  removeDiscounts(index : number){
    this.discounts.removeAt(index);
  }

  submit(){
    this.discounts.push(this.registerForm);
    //console.log(this.registerForm.value);
    console.log(this.registerForm2.value);
  }
}
