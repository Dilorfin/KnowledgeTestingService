import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { ProfileService } from './profile.service';
import { User } from 'src/app/_models/user';

@Component({
	selector: 'app-profile',
	templateUrl: './profile.component.html',
	styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

	private _user : User;
	public get user():User{
		return this._user;
	}
	
	constructor(private authService : AuthService, private profileService : ProfileService) { }

	ngOnInit(): void {
		this.profileService.getCurrentUser().subscribe(
			(user : User)=> this._user = user
		);
	}

	logout() {
		this.authService.logout();
	}
}
