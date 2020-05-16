import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/_models/user';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class ProfileService {

	constructor(private http: HttpClient) { }

	getCurrentUser() : Observable<User> {
		return this.http.get<User>(`${environment.apiUrl}/account/GetCurrentUser`);
	}
}
