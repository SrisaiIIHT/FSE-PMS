import { Component, OnInit } from '@angular/core';
import {TaskInfo} from '../../shared/model/taskinfo';
import {TaskService} from '../../taskinfo/task.service';
import { NgForm, FormBuilder } from '@angular/forms';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { Observable } from 'rxjs';
import { ViewProjectDetails } from '../../shared/model/viewproject';
import { ViewportScroller, NgForOf } from '@angular/common';
import { SearchSortParameter } from '../../shared/model/SearchSortParameter';
import { Options } from 'ng5-slider';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ManagerSearchComponent } from '../../shared/manager-search/manager-search.component';
import { User } from '../../shared/model/user';
import { importType } from '@angular/compiler/src/output/output_ast';
import { ProjectSearchComponent } from '../../shared/project-search/project-search.component';
import {TaskSearchComponent} from '../../shared/task-search/task-search.component';
@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {

  taskInfo: TaskInfo = {
    id: 0,
    ProjectId: 0,
    Project: null,
    Task: "",
    IsParent: false,
    ParentTaskId: 0,
    StartDate: "",
    EndDate: "",
    UserId: 0,
    User: null,
    Priority: 0
};

value: number = 100;
  options: Options = {
    floor: 0,
    ceil: 200
  };

  constructor(private taskService: TaskService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.taskInfo.User = new User();
  }

  onResetClick() {
    this.value = 0;
    this.taskInfo.Priority = null;
  }

  openUserModal()
  {
    const modalRef = this.modalService.open(ManagerSearchComponent);
    modalRef.componentInstance.passEntry.subscribe((selectedUser) => {
      this.taskInfo.UserId = selectedUser.Id;
      this.taskInfo.User = selectedUser;
    })
  }

  openSearchProjectModal(){
    const modalRef = this.modalService.open(ProjectSearchComponent);
    modalRef.componentInstance.passEntry.subscribe((selectedProject) => {
      this.taskInfo.ProjectId = selectedProject.Id;
      this.taskInfo.Project = selectedProject;
    })
  }

  openSearchTaskModal(){
    const modalRef = this.modalService.open(TaskSearchComponent);
    modalRef.componentInstance.passEntry.subscribe((selectedTaskInfo) => {
      this.taskInfo.ParentTaskId = selectedTaskInfo.id;
    })
console.log(this.taskInfo.ParentTaskId);
  }

  saveTask(){ console.log("in save");
 this.taskService.createTask(this.taskInfo).subscribe(
  status => {console.log(status)}
);

  }

}
