import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TestEditingService } from './test-editing.service';
import { NgbTimeMillisecondsAdapter } from './NgbTimeMillisecondsAdapter';
import { NgbTimeAdapter } from '@ng-bootstrap/ng-bootstrap';
import { EditTest, EditQuestion, EditAnswer } from 'src/app/_models/test-management/edit-test';
import { Observable } from 'rxjs';

@Component({
	selector: 'app-test-editing',
	templateUrl: './test-editing.component.html',
	styleUrls: ['./test-editing.component.css'],
	providers: [{ provide: NgbTimeAdapter, useClass: NgbTimeMillisecondsAdapter }]
})
export class TestEditingComponent implements OnInit {
	public errorMessage: string;

	closeErrorMessage() {
		this.errorMessage = null;
	}

	private _testId: number;
	public get testId(): number {
		return this._testId;
	}

	public test: EditTest;

	constructor(private router: Router, private route: ActivatedRoute, private testEditingService: TestEditingService) {
		this._testId = route.snapshot.params['testId'];
	}

	ngOnInit(): void {
		if (this._testId == 0) {
			this.test = new EditTest;
			this.test.questions = [];
			this.addQuestion();
			this.test.time = 0;
			this.test.title = "";
			this.test.description = "";
		}
		else {
			this.testEditingService.getEditTest(this.testId)
				.subscribe(
					(fullTest: EditTest) => {
						this.test = fullTest;
					});
		}
	}

	addQuestion() {
		let question = new EditQuestion;
		question.id = 0;
		question.testId = this.test.id;
		question.answers = [];
		this.addAnswer(question);
		question.answers[0].isCorrect = true;
		this.test.questions.push(question);
	}
	removeQuestion(question: EditQuestion) {
		if (this.test.questions.length > 1) {
			const index = this.test.questions.findIndex(q => q.id == question.id && q.questionText == question.questionText);
			if (index >= 0) {
				this.test.questions.splice(index, 1);
			}
		}
		else this.errorMessage = "Cannot remove last question.";
	}

	addAnswer(question: EditQuestion) {
		let answer = new EditAnswer;
		answer.questionId = question.id;
		question.answers.push(answer);
	}
	removeAnswer(question: EditQuestion, answer: EditAnswer) {
		if (question.answers.length > 1) {
			const index = question.answers.findIndex(a => a.id == answer.id && a.answerText == answer.answerText);
			let isCorrect = answer.isCorrect;
			if (index >= 0) {
				question.answers.splice(index, 1);

				if (isCorrect) {
					question.answers[0].isCorrect = true;
				}
			}
		}
		else this.errorMessage = "Cannot remove last answer.";
	}

	changeCorrectAnswer(question: EditQuestion, answer: EditAnswer): void {
		question.answers.forEach(a => a.isCorrect = false);
		answer.isCorrect = true;
	}

	save() {
		console.log(JSON.stringify(this.test));

		let obs: Observable<void> = null;
		if(this.testId == 0) {
			obs = this.testEditingService.addTest(this.test);
		}
		else obs = this.testEditingService.updateTest(this.test);
		obs.subscribe(
			()=>this.router.navigate(["/admin/tests-management"]),
			(error) => this.errorMessage = error.error
		);
	}

	cancel() {
		this.router.navigate(["/admin/tests-management"]);
	}
}
