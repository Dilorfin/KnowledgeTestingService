import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { User } from 'src/app/_models/user';
import { Items } from 'src/app/_helpers/pagination';

@Injectable({
	providedIn: 'root'
})
export class AdminUsersManagementService {

	constructor(private http: HttpClient) { }

	getAllUsers(offset : number, count : number) : Observable<Items<User>> {
		const params = new HttpParams()
			.set('offset', offset.toString())
			.set('count', count.toString());
		return this.http.get<Items<User>>(`${environment.apiUrl}/account/getallusers`, {params});
	}

	ban(id : string) : Observable<void>{
		return this.http.post<void>(`${environment.apiUrl}/account/ban?userId=${id}`, null);
	}

	unban(id : string) : Observable<void>{
		return this.http.post<void>(`${environment.apiUrl}/account/unban?userId=${id}`, null);
	}
}
