import { Component, OnInit , Inject  , Injectable} from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog'


@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})


@Injectable()
export class DialogComponent implements OnInit {


   _isSuccess : boolean = false;
   _type : string = ""
   _status : boolean = false
   _message : string = ""
   param : any = {}

   color: string = "accent"
   icon : string = "verified"

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this._type  = this.data.type
    this._status = this.data.status
    this._message = this.data.message
    

    if(this._type === DialogTypes.confirm){
      this.color = "primary"
      this.icon = "help"
      this.param = this.data.param
    }
    else if(this._type=== DialogTypes.error){
      this.color = "warn"
       this.icon = "error"
    }

  }

}


export const DialogTypes : any = {
      confirm : "confirm",
      error : "error",
      succeess : "success" 
   } 



