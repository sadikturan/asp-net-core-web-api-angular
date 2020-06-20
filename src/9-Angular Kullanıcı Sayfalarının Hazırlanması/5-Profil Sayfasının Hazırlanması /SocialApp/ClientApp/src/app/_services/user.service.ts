import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
    providedIn: 'root'
})
export class UserService
{
    baseUrl: string = "http://localhost:5000/api/users/";
    constructor(private http: HttpClient) { }
    
    getUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.baseUrl);
    }

    getUser(id: number): Observable<User> {
        return this.http.get<User>(this.baseUrl + id);
    }

}