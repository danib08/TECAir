import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PutService } from 'src/app/Services/put-service';

@Component({
  selector: 'app-manage-promos',
  templateUrl: './manage-promos.component.html',
  styleUrls: ['./manage-promos.component.css']
})
export class ManagePromosComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private apiService: PutService) { }

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
    if(!this.registerForm.valid){
      alert("ERROR");
      return;
    }
    else{
      this.apiService.changeStatus(this.registerForm.value).subscribe(
        res => {
          console.log(res);
        }
      );
      if(this.discounts.length != 0){
        this.apiService.addDiscount(this.discounts.value).subscribe(
          res => {
            console.log(res);
          }
        );
      }

      
      
    }
  }
}
