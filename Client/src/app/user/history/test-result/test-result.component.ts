import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestResultService } from './test-result.service';
import { TestResult } from 'src/app/_models/tests/test-result';

@Component({
	selector: 'app-test-result',
	templateUrl: './test-result.component.html',
	styleUrls: ['./test-result.component.css']
})
export class TestResultComponent implements OnInit {

	public testResult: TestResult;

	constructor(private route: ActivatedRoute, private testResultService: TestResultService) { }

	ngOnInit(): void {
		this.testResultService.getTestResult(this.route.snapshot.params['resultId'])
			.subscribe((testResult: TestResult) => this.testResult = testResult);
	}

	progressBarColor():string{
		if(this.testResult.result >= 75){
			return 'var(--success)';
		}
		if(this.testResult.result >= 50){
			return 'var(--warning)';
		}
		return 'var(--danger)';
	}
}
