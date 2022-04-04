import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

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
    FlightID: ['',Validators.required],
    Discount: [0, Validators.required]
  });

  registerForm2 = this.formBuilder.group({
    Discounts: this.formBuilder.array([], Validators.required)
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
    console.log(this.discounts.at(1).get('Discount')?.value);
    console.log(this.registerForm2.value);
  }
}
