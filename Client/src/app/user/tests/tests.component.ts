import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TestInfo } from 'src/app/_models/tests/test-info';
import { Pagination } from 'src/app/_helpers/pagination';
import { TestsService } from './tests.service';

@Component({
	selector: 'app-tests',
	templateUrl: './tests.component.html',
	styleUrls: ['./tests.component.css']
})
export class TestsComponent extends Pagination<TestInfo> implements OnInit {
	
	constructor(private router: Router, private testsService : TestsService) {
		super((offset, count) => testsService.getTestsInfo(offset, count));
	}

	ngOnInit(): void {
		this.openPage(0);
	}
	openTestInfo(test: TestInfo): void {
		this.router.navigate([`tests/${test.id}`]);
	}
}
