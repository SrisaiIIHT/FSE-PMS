import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../project.service';
import { Project } from '../../shared/model/project';
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
@Component({
  selector: 'app-add-view-project',
  templateUrl: './add-view-project.component.html',
  styleUrls: ['./add-view-project.component.css']
})
export class AddViewProjectComponent implements OnInit {

  value: number = 100;
  options: Options = {
    floor: 0,
    ceil: 200
  };
  emissionRecieved: string;
  SaveUpdateProject: string;
  project: Project = {
    ProjectDesc: "",
    Priority: 0,
    EndDate: null,
    StartDate: null,
    ManagerId: 0,
    StatusDesc: "",
    StatusId: 0,
    Manager: null,
    SetDate: false,
    Id: 0
  };

  viewProjects: ViewProjectDetails[];
  SearchBy: string;

  modalVisible = false;
  constructor(private projectService: ProjectService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.project.Manager = new User();
    this.SaveUpdateProject = "Save";
    // this.viewProjects = [{
    //   ProjectId: 1,
    //   ProjectDesc: 'Test11',
    //   TaskCount: 22,
    //   CompletedTaskCount: 13,
    //   StartDate: '01/01/2017',
    //   EndDate: '01/01/2019',
    //   Priority: 3,
    // }, {
    //   ProjectId: 4,
    //   ProjectDesc: 'Test22',
    //   TaskCount: 22,
    //   CompletedTaskCount: 13,
    //   StartDate: '01/01/2014',
    //   EndDate: '01/01/2020',
    //   Priority: 1,
    // }];

    const filter: SearchSortParameter = { Search: "", SortBy: "ProjectId", Ascending: true };
    this.projectService.searchProjectsInfo(filter).subscribe(data => {
      this.viewProjects = data as ViewProjectDetails[];
    });

  }
  onResetClick() {
    this.value = 0;
    this.project.Priority = null;
  }

  openModal() {
    const modalRef = this.modalService.open(ManagerSearchComponent);
    modalRef.componentInstance.passEntry.subscribe((selectedUser) => {
      this.project.ManagerId = selectedUser.Id;
      this.project.Manager = selectedUser;
    })
  }

  onClose(isVisible: boolean) {
    this.modalVisible = isVisible;
  }

  saveProject(projectForm: NgForm): void {
    if (this.SaveUpdateProject == "Save") {
      var result = this.projectService.createProject(this.project);
    }
    else {
      this.projectService.updateProject(this.project);
      this.SaveUpdateProject = "Save";
      this.value = 0;
      this.project.Priority = null;
    }
    const filter: SearchSortParameter = { Search: "", SortBy: "ProjectId", Ascending: true };
    this.projectService.searchProjectsInfo(filter).subscribe(data => {
      this.viewProjects = data as ViewProjectDetails[];
    });
    projectForm.resetForm();
  }

  toggleDatesEnable(value) {
    console.log(value);
  }

  loadProjectToEdit(projectId: number, projectForm: FormBuilder) {
    this.SaveUpdateProject = "Update";
    this.projectService.getProjectById(projectId).subscribe(data => {
      this.project = data as Project;
    });
  }

  deleteProject(projectId: number) {
    this.projectService.deleteProjectById(projectId);
    const filter: SearchSortParameter = { Search: "", SortBy: "ProjectId", Ascending: true };
    this.projectService.searchProjectsInfo(filter).subscribe(data => {
      this.viewProjects = data as ViewProjectDetails[];
    });
  }

  OnSearchClick() {
    const filter: SearchSortParameter = { Search: this.SearchBy, SortBy: "ProjectId", Ascending: true };
    this.projectService.searchProjectsInfo(filter).subscribe(data => {
      this.viewProjects = data as ViewProjectDetails[];
    });
  }

  OnStartDateSortClick() {
    const filter: SearchSortParameter = { Search: this.SearchBy, SortBy: "StartDate", Ascending: true };
    this.projectService.searchProjectsInfo(filter).subscribe(data => {
      this.viewProjects = data as ViewProjectDetails[];
    });
  }

  OnEndDateSortClick() {
    const filter: SearchSortParameter = { Search: this.SearchBy, SortBy: "EndDate", Ascending: true };
    this.projectService.searchProjectsInfo(filter).subscribe(data => {
      this.viewProjects = data as ViewProjectDetails[];
    });
  }

  OnPrioritySortClick() {
    const filter: SearchSortParameter = { Search: this.SearchBy, SortBy: "Priority", Ascending: true };
    this.projectService.searchProjectsInfo(filter).subscribe(data => {
      this.viewProjects = data as ViewProjectDetails[];
    });
  }

  OnCompletedSortClick() {
    const filter: SearchSortParameter = { Search: this.SearchBy, SortBy: "CompletedTaskCount", Ascending: true };
    this.projectService.searchProjectsInfo(filter).subscribe(data => {
      this.viewProjects = data as ViewProjectDetails[];
    });
  }

}
