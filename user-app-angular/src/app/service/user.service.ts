import { Injectable } from '@angular/core';
import { catchError, map, Observable ,of } from 'rxjs';
import { UserModel } from '../model/user.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http : HttpClient) { }

  private _jsonURL = 'assets/users.json'
 
  private API_URL = "https://localhost:7198/api/User"


  public getUsers() : Observable<UserModel[]>{

    return this.http.get<UserModel[]>(this.API_URL + "/GetAllUsers").pipe(catchError(this.handleError<UserModel[]>("getUsers" , []  )) )

  }

  public saveUser( user : UserModel) : Observable<boolean> {

   
    if(user.id == "0"){

      return this.http.post(this.API_URL + "/AddUser" ,user , {responseType: 'text'  , observe: 'response'}).pipe(
        map(res => {
       
          return res.status === 200 ? true : false
          
        }),
        catchError(this.handleError("saveUser" , false )) )
    }
    else{

      return this.http.put(this.API_URL + "/EditUser" ,user , {responseType: 'text' , observe: 'response'}).pipe(
        map(res => {
        
          return res.status === 200 ? true : false
          
        }),
        catchError(this.handleError("saveUser" , false )) )
    
    }

  }

  deleteUser(id : string) : Observable<boolean>{
console.log(id)
      return this.http.delete(this.API_URL + "/DeleteUser?id=" + id ,{responseType: 'text' , observe: 'response'}).pipe(
         map(res => {
        
          return res.status === 200 ? true : false
          
        }),
        catchError(this.handleError("deleteUser" , false)))

  }


    private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
