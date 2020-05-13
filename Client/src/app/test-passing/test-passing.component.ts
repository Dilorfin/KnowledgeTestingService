import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestPassingService } from './test-passing.service';

@Component({
	selector: 'app-test-passing',
	templateUrl: './test-passing.component.html',
	styleUrls: ['./test-passing.component.css']
})
export class TestPassingComponent implements OnInit {

	constructor(route: ActivatedRoute, testPassingService: TestPassingService) {
		testPassingService.loadTest(route.snapshot.params['testId']);
	}

	ngOnInit(): void {}
}
