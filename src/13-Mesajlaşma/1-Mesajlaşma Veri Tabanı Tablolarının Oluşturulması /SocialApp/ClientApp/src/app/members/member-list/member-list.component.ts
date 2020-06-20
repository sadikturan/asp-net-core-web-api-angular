import { Component, OnInit } from '@angular/core';
import { UserService } from '../../_services/user.service';
import { User } from '../../_models/user';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  users: User[];
  public loading = false;
  userParams: any = {};

  constructor(private userService: UserService, private alertify: AlertifyService) { }

  ngOnInit(): void {
    this.userParams.orderby = "lastactive";
    // this.userParams.gender = "female";
    // this.userParams.minAge = 20;
    // this.userParams.maxAge = 40;
    this.getUsers();
  }

  getUsers() {
    this.loading = true;

    this.userService.getUsers(null,this.userParams).subscribe(users => {
      this.loading = false;
      this.users = users;
    }, err => {
      this.loading = false;
      this.alertify.error(err);
    })
  }

}
