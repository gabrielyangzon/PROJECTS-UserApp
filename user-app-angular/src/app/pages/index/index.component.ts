import { Component, OnInit } from '@angular/core';

import { UserModel } from '../../model/user.model';

import { UserService } from '../../service/user.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  constructor(private userService : UserService) { }

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
    this.userService.getUsers().subscribe(response => {
      this.Users = response 
    })

 
  }


  addUser(){
    console.log("Hello world")
  }

}
