import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-member-details',
  templateUrl: './member-details.component.html',
  styleUrls: ['./member-details.component.css']
})
export class MemberDetailsComponent implements OnInit {

  user: User;
  followText: string = "Takip Et";

  constructor(private userService: UserService, 
    private alertify: AlertifyService,
    private authService: AuthService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data=> {
      this.user = data.user;
    })
  }

  followUser(userId: number) {
    this.userService.followUser(this.authService.decodedToken.nameid, userId)
        .subscribe(result => {
          this.alertify.success(this.user.name + ' kullanıcısını takip ediyorsunuz');
          this.followText = "Takip Ediyorsunuz";
        }, err => {
          this.alertify.error(err);
        })
  }


}
