import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { User } from '../_models/user';
import { Observable, of } from 'rxjs';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { catchError } from 'rxjs/operators';

@Injectable()
export class MemberEditResolver implements Resolve<User> {

    constructor(private userService: UserService, 
        private alertify: AlertifyService, 
        private authService: AuthService,
        private route: Router) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): User | Observable<User> | Promise<User> {
        return this.userService
        .getUser(this.authService.decodedToken.nameid)
        .pipe(catchError(error=> {
            this.alertify.error("server error");
            this.route.navigate(['/members']);
            return of(null);
        }))
    }

}