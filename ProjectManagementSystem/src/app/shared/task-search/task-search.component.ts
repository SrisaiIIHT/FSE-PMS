import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TaskService } from '../../taskinfo/task.service';
import { TaskInfo } from '../../shared/model/taskinfo';
import { NgForm, FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { ViewportScroller, NgForOf } from '@angular/common';
import { SearchSortParameter } from '../../shared/model/SearchSortParameter';
import { Options } from 'ng5-slider';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-task-search',
  templateUrl: './task-search.component.html',
  styleUrls: ['./task-search.component.css']
})
export class TaskSearchComponent implements OnInit {

  taskInfos: Observable<TaskInfo[]>;
  selectedTaskInfo: TaskInfo;

  @Output() passEntry: EventEmitter<TaskInfo> = new EventEmitter();
  @Output() closeModalEvent = new EventEmitter<boolean>();

  constructor(private taskService: TaskService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.loadTaskInfos();
  }

  loadTaskInfos() {
    this.taskInfos = this.taskService.getAllTasks();
  }

  onSelectionChange(selectedTaskInfo) {
    this.selectedTaskInfo = selectedTaskInfo;
  }

  passBack() {
    this.passEntry.emit(this.selectedTaskInfo);
  }

  onCloseModal(event: any) {
    this.closeModalEvent.emit(false);
  }
}