import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model: any = {};

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log("login başarılı");
      this.router.navigate(['/members']);
    }, error => {
      console.log("login hatalı");
    })
  }

  loggedIn() {
    const token = localStorage.getItem("token");
    return token?true:false;
  }

  logout() {
    localStorage.removeItem("token");
    console.log("logout");
    this.router.navigate(['/home']);
  }

}
