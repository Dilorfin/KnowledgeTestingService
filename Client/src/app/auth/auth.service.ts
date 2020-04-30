import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { Token } from '../_models/token';

@Injectable()
export class AuthService {
	public token: Token;
	
	constructor(private http: HttpClient) {
		let stored_token = localStorage.getItem('access_token');
		if(stored_token) {
			this.token = JSON.parse(stored_token);
		}
	}

	public get isAuthorized(): boolean {
		return this.token ? true : false;
	}

	login(username: string, password: string): Observable<Token> {
		const model = {
			username: username,
			password: password
		};

		let obs = this.http.post<Token>(`${environment.apiUrl}/authentication/login`, model);
		obs.subscribe((token: Token) => {
				this.token = token;
				localStorage.setItem('access_token', JSON.stringify(token));
			});
		return obs;
	}

	register(username: string, password: string, email?: string): Observable<Object> {
		const model = {
			username: username,
			password: password,
			email: email
		};
		return this.http.post<Token>(`${environment.apiUrl}/authentication/register`, model);
	}

	logout(): void {
		localStorage.removeItem('access_token');
		this.token = undefined;
		location.reload();
	}
}
