import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule,HttpClient} from '@angular/common/http'
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
import { AddViewProjectComponent } from './project/add-view-project/add-view-project.component';
import { ViewTaskComponent } from './taskinfo/view-task/view-task.component';
import { AddTaskComponent } from './taskinfo/add-task/add-task.component';
import { AddViewComponent } from './user/add-view/add-view.component';
import { UserService } from './user/user.service';
import { TaskService } from './taskinfo/task.service';
import { ProjectService } from './project/project.service';
import {BsDatepickerModule} from 'ngx-bootstrap/datepicker';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { Ng5SliderModule } from 'ng5-slider';
import { ManagerSearchComponent } from './shared/manager-search/manager-search.component';
import { ProjectSearchComponent } from './shared/project-search/project-search.component';
import { TaskSearchComponent } from './shared/task-search/task-search.component';

@NgModule({
  declarations: [
    AppComponent, 
    HeaderComponent,
    FooterComponent,
    AddViewProjectComponent,
    ViewTaskComponent,
    AddTaskComponent,
    AddViewComponent,
    ManagerSearchComponent,
    ProjectSearchComponent,
    TaskSearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule, 
    ReactiveFormsModule,
    HttpClientModule, 
    BrowserAnimationsModule,    
    BsDatepickerModule.forRoot(),
    NgbModule, 
    Ng5SliderModule,
  ],
  providers: [HttpClientModule,UserService,TaskService,ProjectService],
  bootstrap: [AppComponent],
  entryComponents:[ ManagerSearchComponent, ProjectSearchComponent,TaskSearchComponent]
})
export class AppModule { }
