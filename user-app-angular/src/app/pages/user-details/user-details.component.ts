import { Component, OnInit , ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from '../../model/user.model';
import { UserService } from '../../service/user.service';
import {MatDialog} from '@angular/material/dialog';

import { DialogComponent , DialogTypes} from '../../components/dialog/dialog.component'
@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

 public userData :UserModel = {} as UserModel

 emailFormControl = new FormControl('', [Validators.required, Validators.email]);

 

 constructor(
   public activatedRoute : ActivatedRoute ,
   private  userService : UserService , 
   private dialog : MatDialog,
   private router : Router) { }


  ngOnInit(): void {
 
     if(history.state['user'] !== undefined)
     {
        this.userData  = history.state['user']
     }
    

     console.log(this.userData)
  }

  ngOnDestroy(){
    this.userData  = {} as UserModel
  }


  getKeys = (obj :any) : boolean => Object.keys(obj).length !== 0

  saveUser(){
  
      this.userService.saveUser(this.userData).subscribe(isOk => {
         if(isOk){

           

          this.dialog.open(DialogComponent , {data : { 
             type : DialogTypes.succeess ,
             message : "User details saved succesfully ",
             status : true
          }})

          this.router.navigate([''])
         }
      })
  }





}
