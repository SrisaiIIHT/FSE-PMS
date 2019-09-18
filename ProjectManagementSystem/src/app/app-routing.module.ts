import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AddViewProjectComponent} from './project/add-view-project/add-view-project.component';
import {AddTaskComponent} from './taskinfo/add-task/add-task.component';
import {ViewTaskComponent} from './taskinfo/view-task/view-task.component';
import {AddViewComponent} from './user/add-view/add-view.component';

const routes: Routes = [
  {path:"add-project",component:AddViewProjectComponent},
{path:"add-task",component: AddTaskComponent},
{path:"add-user",component: AddViewComponent},
{path:"view-task",component: ViewTaskComponent},
{path:"**",component: AddViewProjectComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
