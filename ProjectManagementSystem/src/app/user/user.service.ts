import {Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {map, catchError, retry} from 'rxjs/operators'
import {User} from '../shared/model/user'



@Injectable({
  providedIn: 'root'
})
export class UserService {

  url_user: "http://localhost:49622/api/User";
  public users: User[] = [];

  constructor(private http: HttpClient) { }

  getAllUsers(): Observable<User[]>{ 
    return this.http.get<User[]>("http://localhost:49622/api/User/GetAllUsers");  //  return this.http.get<User[]>("http://localhost:49622/api/User/GetAllUsers")
   
  }

  getUserById(userId: number):Observable<User>{
    return this.http.get<User>(this.url_user + "/GetUser/" + userId);

  }

  createUser(user:User): Observable<User>{
    const httpOptions = {headers: new HttpHeaders({'Content-Type':'application/json'})};
    return this.http.post<User>(this.url_user + 'InsertUser',user, httpOptions);
  }

  updateUser(user:User): Observable<User>{
    const httpOptions = {headers: new HttpHeaders({'Content-Type':'application/json'})};
    return this.http.post<User>(this.url_user + 'UpdateUser',user, httpOptions);
  }

  deleteUserById(userId:number): Observable<User>{
    const httpOptions = {headers: new HttpHeaders({'Content-Type':'application/json'})};
    return this.http.post<User>(this.url_user + 'DeleteUser'+userId, httpOptions);
  } 
}
