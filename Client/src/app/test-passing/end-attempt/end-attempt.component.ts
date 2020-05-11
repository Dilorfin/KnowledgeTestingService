import { Component, OnInit } from '@angular/core';
import { TestPassingService } from '../test-passing.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { TestResult } from 'src/app/_models/tests/test-result';

@Component({
	selector: 'app-end-attempt',
	templateUrl: './end-attempt.component.html',
	styleUrls: ['./end-attempt.component.css']
})
export class EndAttemptComponent implements OnInit {
	private querySubscription: Subscription;
	private id: number;
	public testResult:TestResult;

	constructor(private route: ActivatedRoute, private testPassingService: TestPassingService) {
		this.querySubscription = route.queryParams.subscribe(
			(queryParam: any) => {
				this.id = queryParam['id'];
				this.testPassingService.getTestResult(this.id).subscribe(
					(testResult:TestResult)=> this.testResult=testResult
				)
			}
		);
	}


	ngOnInit(): void {
		
	}

}
