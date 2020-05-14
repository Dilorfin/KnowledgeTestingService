import { Component, OnInit } from '@angular/core';
import { TestResult } from 'src/app/_models/tests/test-result';
import { Pagination } from 'src/app/_helpers/pagination';
import { HistoryService } from './history.service';

@Component({
	selector: 'app-history',
	templateUrl: './history.component.html',
	styleUrls: ['./history.component.css']
})
export class HistoryComponent extends Pagination<TestResult> implements OnInit {

	constructor(private historyService: HistoryService) {
		super((offset, count)=>this.historyService.getAllResults(offset, count));
	}

	ngOnInit(): void {
		this.openPage(0);
	}

}
