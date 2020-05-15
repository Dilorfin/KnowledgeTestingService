import { Component, OnInit } from '@angular/core';
import { TestPassingService } from '../test-passing.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FullTest } from 'src/app/_models/test-querying/full-test';

@Component({
	selector: 'app-start-attempt',
	templateUrl: './start-attempt.component.html',
	styleUrls: ['./start-attempt.component.css']
})
export class StartAttemptComponent implements OnInit {

	public get test() : FullTest {
		return this.testPassingService.test;
	}
	
	constructor(private router: Router, private route: ActivatedRoute,
		private testPassingService: TestPassingService)
	{}

	ngOnInit(): void {}

	startTest(): void {
		this.testPassingService.startTest();
		this.router.navigate(["../questions"], { relativeTo: this.route });
	}
}
