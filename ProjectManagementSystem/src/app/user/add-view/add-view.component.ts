import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { UserService } from '../../user/user.service';
import { User } from '../../shared/model/user';
import { SearchSortParameter } from '../../shared/model/SearchSortParameter';

@Component({
  selector: 'app-add-view',
  templateUrl: './add-view.component.html',
  styleUrls: ['./add-view.component.css']
})
export class AddViewComponent implements OnInit {

  allUsers: Observable<User[]>;

  user: User = {
    EmployeeId: "",
    FirstName: "",
    LastName: "",
    Id: 0,
    Active: true
  };

  searchSort: SearchSortParameter = {
    Search: "",
    SortBy: "",
    Ascending: true
  };
  constructor(private userService: UserService) { }


  ngOnInit() {
    this.loadAllUsers();
  }

  loadAllUsers() {
    this.allUsers = this.userService.getAllUsers();
  }
  loadUserToEdit(userId: number) {
    console.log("edit " + userId);
  }

  deleteUser(userId: number) {
    console.log("delete " + userId);
  }


}
