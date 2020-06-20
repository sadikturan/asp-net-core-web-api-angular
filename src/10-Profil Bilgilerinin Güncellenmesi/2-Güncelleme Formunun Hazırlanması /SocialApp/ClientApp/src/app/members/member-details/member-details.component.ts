import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-member-details',
  templateUrl: './member-details.component.html',
  styleUrls: ['./member-details.component.css']
})
export class MemberDetailsComponent implements OnInit {

  user: User;

  constructor(private userService: UserService, 
    private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getUser();
  }

  // members/3
  getUser() {
    this.userService.getUser(+this.route.snapshot.params['id']).subscribe(user => {
      this.user = user;
    }, err => {
      this.alertify.error(err);
    });
  }

}
