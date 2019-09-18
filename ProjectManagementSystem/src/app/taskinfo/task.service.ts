import {Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {map, catchError, retry} from 'rxjs/operators'
import {User} from '../shared/model/user'
import { TaskInfo } from '../shared/model/taskinfo';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  
  url_task : string;

  constructor(private http: HttpClient) { }

  getAllTasks(): Observable<TaskInfo[]>{ 
    return this.http.get<TaskInfo[]>("http://localhost:49622/api/Task/GetAllTaskDetails"); 
  }

  getTaskById(taskId: number):Observable<TaskInfo>{
    return this.http.get<TaskInfo>(this.url_task + "/GetUser/" + taskId);
  }

  createTask(task:TaskInfo): Observable<TaskInfo>{
    const httpOptions = {headers: new HttpHeaders({'Content-Type':'application/json'})};
    return this.http.post<TaskInfo>('http://localhost:49622/api/Task/InsertTaskDetail',task, httpOptions);
  }

  updateTask(task:TaskInfo): Observable<TaskInfo>{
    const httpOptions = {headers: new HttpHeaders({'Content-Type':'application/json'})};
    return this.http.post<TaskInfo>('http://localhost:49622/api/Task/UpdateTaskDetail',task, httpOptions);
  }

  deleteTaskById(taskId:number): Observable<TaskInfo>{
    const httpOptions = {headers: new HttpHeaders({'Content-Type':'application/json'})};
    return this.http.post<TaskInfo>(this.url_task + 'DeleteUser'+taskId, httpOptions);
  } 
}
