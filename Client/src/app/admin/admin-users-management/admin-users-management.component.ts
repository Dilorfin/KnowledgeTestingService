import { AdminUsersManagementService } from './admin-users-management.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { Pagination } from 'src/app/_helpers/pagination';

@Component({
	selector: 'app-admin-users-management',
	templateUrl: './admin-users-management.component.html',
	styleUrls: ['./admin-users-management.component.css']
})
export class AdminUsersManagementComponent extends Pagination<User> implements OnInit {
	
	constructor(private userManagementService: AdminUsersManagementService) {
		super((offset, count) => userManagementService.getAllUsers(offset, count));
	}

	ngOnInit(): void {
		this.openPage(0);
	}

	ban(id: string) {
		this.userManagementService.ban(id)
			.subscribe(
				() => this.openPage(this.currentPage),
				error => console.log(error)
			);
	}

	unban(id: string) {
		this.userManagementService.unban(id)
			.subscribe(
				() => this.openPage(this.currentPage),
				error => console.log(error)
			);
	}
}
