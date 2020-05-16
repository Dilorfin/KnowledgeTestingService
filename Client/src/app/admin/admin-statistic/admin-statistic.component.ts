import { Component, OnInit } from '@angular/core';
import { Pagination } from 'src/app/_helpers/pagination';
import { TestGeneralStatistic } from 'src/app/_models/test-result/test-general-statistic';
import { AdminStatisticService } from './admin-statistic.service';

@Component({
	selector: 'app-admin-statistic',
	templateUrl: './admin-statistic.component.html',
	styleUrls: ['./admin-statistic.component.css']
})
export class AdminStatisticComponent extends Pagination<TestGeneralStatistic> implements OnInit {

	constructor(adminStatisticService: AdminStatisticService) {
		super((offset, count) => adminStatisticService.getAllTestsGeneralStatistic(offset, count));
	}

	ngOnInit(): void {
		this.openPage(0);
	}
}
