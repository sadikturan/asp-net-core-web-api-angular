import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
    providedIn: 'root'
})
export class UserService
{
    baseUrl: string = "http://localhost:5000/api/users/";
    constructor(private http: HttpClient) { }
    
    getUsers(followParams?): Observable<User[]> {

        let params = new HttpParams();

        if(followParams === 'followers') {
            params = params.append('followers','true');
        }

        if(followParams === 'followings') {
            params = params.append('followings','true');
        }

        return this.http.get<User[]>(this.baseUrl, {params: params});
    }

    getUser(id: number): Observable<User> {
        return this.http.get<User>(this.baseUrl + id);
    }

    updateUser(id: number, user: User) {
        return this.http.put(this.baseUrl + id, user);
    }

    followUser(followerId: number, userId: number) {
        return this.http.post(this.baseUrl + followerId + '/follow/' + userId,{});
    }

}