import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestsService } from '../tests.service';
import { TestInfo } from 'src/app/_models/tests/test-info';

@Component({
	selector: 'app-test-card',
	templateUrl: './test-card.component.html',
	styleUrls: ['./test-card.component.css']
})
export class TestCardComponent implements OnInit {
	private id: number;
	public testInfo : TestInfo = null;
	constructor(private activateRoute: ActivatedRoute, private testsService : TestsService) {
		this.id = activateRoute.snapshot.params['id'];
		
	}

	ngOnInit(): void {
		this.testsService.getTestInfo(this.id)
			.subscribe(
				(test:TestInfo)=> this.testInfo=test
			);
	}

}
