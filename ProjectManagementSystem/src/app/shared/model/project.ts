import { User } from './user';

export class Project {
    Id:number;
    ProjectDesc: string;
    StartDate: string;
    EndDate: string;
    ManagerId: number;
    Priority: number;
    StatusId: number;
    StatusDesc: string;
    Manager: User;
    SetDate:boolean;
}