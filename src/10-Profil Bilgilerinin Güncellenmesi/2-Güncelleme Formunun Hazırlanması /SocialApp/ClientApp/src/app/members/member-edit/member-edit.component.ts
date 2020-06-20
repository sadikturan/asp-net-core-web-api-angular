import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {

  user: User;

  constructor(private userService: UserService, 
    private alertify: AlertifyService, 
    private authService: AuthService) { }

  ngOnInit(): void {
    this.getUser();
  }


  getUser() {
    this.userService.getUser(this.authService.decodedToken.nameid).subscribe(user=> {
      this.user = user;
    }, err => {
      this.alertify.error(err);
    })
  }

}
