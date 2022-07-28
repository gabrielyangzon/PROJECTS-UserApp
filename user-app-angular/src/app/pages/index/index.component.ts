import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent, DialogTypes } from '../../components/dialog/dialog.component';

import { UserModel } from '../../model/user.model';

import { UserService } from '../../service/user.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})


export class IndexComponent implements OnInit {


  constructor(private userService : UserService,
              private dialog: MatDialog) { }

  UserType : UserModel = {
    id : "",
    name : "", 
    email : "",
    phone : "",
     // address : "",
     // username :"",
    // website : "",
  }

  Users : UserModel[] = []

  ngOnInit(): void {
   this.getUsers()
  }

  getUsers(){
     this.userService.getUsers().subscribe(response => {
      this.Users = response 
    })
  }



   async deleteUser(id : string){
     const dialogRef =  this.dialog.open(DialogComponent,{data :{
           type : DialogTypes.confirm ,
           message : "Are you sure you want to delete?",
           status : true,
           param : id
      }})

      dialogRef.afterClosed().subscribe(result => {
        
         this.userService.deleteUser(result).subscribe(async response => {
            
            await this.dialog.open(DialogComponent , {data : {  
                 type : response ?  DialogTypes.success : DialogTypes.error ,
                 message : response ? "User Deleted" : "error deleting user",
                 status : true

              }})
            
              this.ngOnInit()

         })
    });
  }

}
