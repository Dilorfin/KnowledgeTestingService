import { AdminUsersManagementService, Users } from './admin-users-management.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { error } from 'protractor';

@Component({
	selector: 'app-admin-users-management',
	templateUrl: './admin-users-management.component.html',
	styleUrls: ['./admin-users-management.component.css']
})
export class AdminUsersManagementComponent implements OnInit {
	public usersCount: number = 0;
	public users: User[] = [];

	public currentPage: number = 0;
	private usersPerPage: number = 15;

	public get pagesNumber(): number {
		return Math.ceil(this.usersCount / this.usersPerPage);
	}

	formateDate(n : number):string{
		if(n)return new Date(n).toLocaleString();
		return null;
	}
	constructor(private userManagementService: AdminUsersManagementService) {
		this.openPage(0);
	}

	ngOnInit(): void {
	}

	lockout(id : string) {
		this.userManagementService.lockout(id)
			.subscribe(
				()=> this.openPage(this.currentPage),
				error=>console.log(error)
			);
	}

	public get isFirstPage(): boolean {
		return this.currentPage == 0;
	}

	public get isLastPage(): boolean {
		return this.currentPage == this.pagesNumber-1;
	}

	openPage(page: number) {
		const offset = page * this.usersPerPage;
		this.userManagementService.getAllUsers(offset, this.usersPerPage)
			.subscribe((users: Users) => {
				this.users = users.userModels;
				this.usersCount = users.usersCount;
				this.currentPage = page;
			});
	}
}
