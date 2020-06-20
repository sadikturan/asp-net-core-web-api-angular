import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {

  user: User;

  constructor(private route: ActivatedRoute, 
    private userService: UserService, 
    private alertify: AlertifyService, 
    private authService: AuthService) { }

  ngOnInit(): void {
    this.route.data.subscribe(data=> {
      this.user = data.user;
    })
  }

  updateUser() {
    this.userService.updateUser(this.authService.decodedToken.nameid, this.user)
    .subscribe(()=> {
      this.alertify.success("profiliniz güncellendi.");
    }, err => {
      this.alertify.error(err);
    })
  }
}
