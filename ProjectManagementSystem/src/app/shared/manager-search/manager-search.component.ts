import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../../shared/model/user';
import { UserService } from '../../user/user.service';
@Component({
  selector: 'app-manager-search',
  templateUrl: './manager-search.component.html',
  styleUrls: ['./manager-search.component.css']
})
export class ManagerSearchComponent implements OnInit {

  allUsers: Observable<User[]>;
  selectedUser:User;
  user: User = {
    EmployeeId: "",
    FirstName: "",
    LastName: "",
    Id: 0,
    Active: true
  };
  @Output() passEntry: EventEmitter<User> = new EventEmitter();
  @Output() closeModalEvent = new EventEmitter<boolean>();


  @Input() public testuser;
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.loadAllUsers();
  }

  loadAllUsers() {
    this.allUsers = this.userService.getAllUsers();
  }

  onSelectionChange(selectedUser) {
    this.selectedUser = selectedUser;
}

  passBack() {
    this.passEntry.emit(this.selectedUser);
  }

  onCloseModal(event: any) {
    this.closeModalEvent.emit(false);
  }

}
