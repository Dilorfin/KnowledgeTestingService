import { Component, OnInit } from '@angular/core';
import { Pagination } from 'src/app/_helpers/pagination';
import { TestInfo } from 'src/app/_models/tests/test-info';
import { TestsService } from 'src/app/user/tests/tests.service';

@Component({
	selector: 'app-admin-tests-management',
	templateUrl: './admin-tests-management.component.html',
	styleUrls: ['./admin-tests-management.component.css']
})
export class AdminTestsManagementComponent extends Pagination<TestInfo> implements OnInit {

	constructor(testsService: TestsService) {
		super((offset, count, filter) => testsService.getTestsInfo(offset, count, filter));
	}

	ngOnInit(): void {
		this.openPage(0);
	}
}
