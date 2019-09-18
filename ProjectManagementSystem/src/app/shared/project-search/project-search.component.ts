import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProjectService } from '../../project/project.service';
import { Project } from '../../shared/model/project';
import { NgForm, FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { ViewportScroller, NgForOf } from '@angular/common';
import { SearchSortParameter } from '../../shared/model/SearchSortParameter';
import { Options } from 'ng5-slider';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from '../../shared/model/user';

@Component({
  selector: 'app-project-search',
  templateUrl: './project-search.component.html',
  styleUrls: ['./project-search.component.css']
})
export class ProjectSearchComponent implements OnInit {

  projects: Observable<Project[]>;
  selectedProject: Project;

  @Output() passEntry: EventEmitter<Project> = new EventEmitter();
  @Output() closeModalEvent = new EventEmitter<boolean>();

  constructor(private projectService: ProjectService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.loadProjects();
  }

  loadProjects() {
    this.projects = this.projectService.getAllProject();
  }

  onSelectionChange(selectedProject) {
    this.selectedProject = selectedProject;
  }

  passBack() {
    this.passEntry.emit(this.selectedProject);
  }

  onCloseModal(event: any) {
    this.closeModalEvent.emit(false);
  }
}
