
import { Project } from './project'
import { User } from './user'
export class TaskInfo {

    id: number;
    ProjectId: number;
    Project: Project;
    Task: string;
    IsParent: boolean;
    ParentTaskId: number;
    StartDate: string;
    EndDate: string;
    UserId: number;
    User: User;
    Priority: number;
}