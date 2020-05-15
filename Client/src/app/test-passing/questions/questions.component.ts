import { Component, OnInit } from '@angular/core';
import { TestPassingService } from '../test-passing.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Question, FullTest } from 'src/app/_models/test-querying/full-test';
import { Observable } from 'rxjs';

@Component({
	selector: 'app-questions',
	templateUrl: './questions.component.html',
	styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

	constructor(private router: Router, private route: ActivatedRoute,
		private testPassingService: TestPassingService) { }

	ngOnInit(): void {
		if (!this.testPassingService.isPassing()) {
			this.router.navigate(["../start"], { relativeTo: this.route });
		}

		this.testPassingService.setOnFinish((obs : Observable<number>)=>{
			obs.subscribe((resultId: number) => {
					this.router.navigate([`result/${resultId}`] );
				});
		});
	}
	public questionIndex: number = 0;

	public get test(): FullTest {
		return this.testPassingService.test;
	}
	public get question(): Question {
		if (this.testPassingService.test) {
			return this.testPassingService.test.questions[this.questionIndex];
		}
		return null;
	}

	public get checkedAnswer(): number {
		if (this.testPassingService.test) {
			return this.testPassingService.getCheckedAnswer(this.question.id);
		}
		return null;
	}

	public nextQuestion() {
		this.questionIndex++;
	}

	public previousQuestion() {
		this.questionIndex--;
	}

	public get timeLeft(): number {
		return this.testPassingService.timeLeft;
	}

	public setAnswer(answerId: number) {
		this.testPassingService.setAnswer(this.question.id, answerId);
	}

	finishTest(): void {
		this.testPassingService.finishTest();
	}
}
