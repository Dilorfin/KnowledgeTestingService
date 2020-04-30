import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { User } from 'src/app/_models/user';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class AdminUsersManagementService {

	constructor(private http: HttpClient) { }

	getAllUsers(offset : number, count : number) : Observable<Users> {
		const params = new HttpParams()
			.set('offset', offset.toString())
			.set('count', count.toString());
		return this.http.get<Users>(`${environment.apiUrl}/account/getallusers`, {params});
	}

	lockout(id : string) : Observable<void>{
		return this.http.post<void>(`${environment.apiUrl}/account/lockout?id=${id}`, null);
	}
}
export class Users {
	usersCount:number;
	userModels:User[];
}