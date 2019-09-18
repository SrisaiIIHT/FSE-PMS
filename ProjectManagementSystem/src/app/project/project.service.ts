import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError, retry } from 'rxjs/operators'
import { User } from '../shared/model/user'
import { Project } from '../shared/model/project';
import { ViewProjectDetails } from '../shared/model/viewproject';
import { SearchSortParameter } from '../shared/model/SearchSortParameter';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {


  url_task: string;
  projectViewInfo: Observable<ViewProjectDetails[]>;
  private result: Observable<any[]>;
  resultViewProjects: ViewProjectDetails[] = [];
  result1: Array<ViewProjectDetails>;
  constructor(private http: HttpClient) { }

  private handleError(error: any) {
    console.log(error);
    return throwError;
  }



  searchProject(search: string, sortBy: string, ascending: boolean): Observable<ViewProjectDetails[]> {
    var x;
    const param: string = "searchBy=" + search + "&&sortBy=" + sortBy + "&&ascending=" + ascending;

    //var httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.get<ViewProjectDetails[]>('http://localhost:49622/api/Project/GetViewProjectsDetails?' + param)
  }

  searchProjectsInfo(filter: SearchSortParameter): Observable<ViewProjectDetails[]> {
    var x;
    const param: SearchSortParameter = { Search: filter.Search, SortBy: filter.SortBy, Ascending: filter.Ascending };

    var httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<ViewProjectDetails[]>('http://localhost:49622/api/Project/GetViewProjectsFiltered', param, httpOptions);
  }

  getAllProject(): Observable<Project[]> {
    return this.http.get<Project[]>("http://localhost:49622/api/Project/GetAllProjectDetails");
  }

  getProjectById(projectId: number): Observable<Project> {
    return this.http.get<Project>("http://localhost:49622/api/Project/GetProjectDetail/" + projectId);
  }

  createProject(project: Project) {
    var httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    this.http.post<Project>(
      'http://localhost:49622/api/Project/InsertProjectDetail', project, httpOptions).subscribe();
  }

  updateProject(project: Project): Observable<Project> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Project>(this.url_task + 'UpdateProjectDetail', project, httpOptions);
  }

  deleteProjectById(projectId: number): Observable<Project> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Project>(this.url_task + 'DeleteProjectDetail' + projectId, httpOptions);
  }
}
