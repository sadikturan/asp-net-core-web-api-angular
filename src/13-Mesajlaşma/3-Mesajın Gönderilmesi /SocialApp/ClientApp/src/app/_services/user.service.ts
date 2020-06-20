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
    
    getUsers(followParams?, userParams?): Observable<User[]> {

        let params = new HttpParams();

        if(followParams === 'followers') {
            params = params.append('followers','true');
        }

        if(followParams === 'followings') {
            params = params.append('followings','true');
        }

        if(userParams!=null) {
            if(userParams.gender!=null) 
                params = params.append('gender',userParams.gender);
            if(userParams.minAge!=null) 
                params = params.append('minAge',userParams.minAge);
            if(userParams.maxAge!=null) 
                params = params.append('maxAge',userParams.maxAge);
            if(userParams.country!=null) 
                params = params.append('country',userParams.country);
            if(userParams.city!=null) 
                params = params.append('city',userParams.city);
            if(userParams.orderby!=null)
                params = params.append("orderby", userParams.orderby);
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

    sendMessage(id: number, message: any) {
        return this.http.post(this.baseUrl + id + '/messages/', message);
    }

}