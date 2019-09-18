import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { TaskService } from '../../taskinfo/task.service';
import { TaskInfo } from '../../shared/model/taskinfo';
import { HttpClient } from 'selenium-webdriver/http';

@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrls: ['./view-task.component.css']
})
export class ViewTaskComponent implements OnInit {

  allTasks: Observable<TaskInfo[]>;

  constructor(private taskservice: TaskService) { }

  ngOnInit() {
    this.loadAllTasks();
  }

  loadAllTasks() {
    this.allTasks = this.taskservice.getAllTasks();
  }

  loadTaskToEdit(taskId: number) {
    console.log("edit " + taskId);
  }

  deleteTask(taskId: number) {
    console.log("delete " + taskId);
  }
}
