import { Component, OnInit } from '@angular/core';
import { TestInfo } from 'src/app/_models/tests/test-info';
import { Pagination } from 'src/app/_helpers/pagination';
import { TestsService } from './tests.service';

@Component({
	selector: 'app-tests',
	templateUrl: './tests.component.html',
	styleUrls: ['./tests.component.css']
})
export class TestsComponent extends Pagination<TestInfo> implements OnInit {
	
	constructor(testsService : TestsService) {
		super((offset, count, filter) => testsService.getTestsInfo(offset, count, filter));
	}

	ngOnInit(): void {
		this.openPage(0);
	}
}
