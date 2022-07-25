import { Component, OnInit , EventEmitter , Output, Input  } from '@angular/core';

import { FormControl , FormGroup } from '@angular/forms';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {


  @Output() onAddUserClick = new EventEmitter()

  @Input() data : any 

  formGroup : FormGroup  = new FormGroup({})
  

  constructor() { }

  ngOnInit(): void {
    // this.formGroup = new FormGroup()
    
    

    for(let property in this.data){
      

    console.log()

      Object.assign(this.formGroup.controls , { [property] : new FormControl()} )
     

    }

    console.log(this.formGroup.controls)


    let str  = "abc"

    let ending = "bc"
    


    let res = str.split("").splice(ending.length,ending.length)

    console.log(res)
  

  }

  onAddUserClickHandler () {
    this.onAddUserClick.emit()
  }



}
