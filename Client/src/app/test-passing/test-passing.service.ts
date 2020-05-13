import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FullTest } from '../_models/tests/full-test';
import { environment } from 'src/environments/environment';
import { UserAnswers, UsersAnswer } from '../_models/tests/user-answers';
import { TestResult } from '../_models/tests/test-result';

@Injectable()
export class TestPassingService {
	
	private onFinish : (obs : Observable<number>) => void;
	public setOnFinish(func : (obs : Observable<number>) => void){
		this.onFinish = func;
	}

	constructor(private http: HttpClient) { }
	
	private interval;
	private userAnswers: UserAnswers;
	
	private _isPassing: boolean = false;

	public isPassing(): boolean {
		return this._isPassing;
	}

	private _timeLeft: number;
	public get timeLeft(): number {
		return this._timeLeft;
	}

	private _test: FullTest;
	public get test(): FullTest {
		return this._test;
	}

	public loadTest(testId: number | string): Observable<FullTest> {
		let obs = this.getFullTest(testId);
		obs.subscribe(
			(test: FullTest) => this._test = test
		);
		return obs;
	}
	public startTest(): void {
		this._isPassing = true;
		this._timeLeft = this.test.time;
		this.interval = setInterval(() => {
			if (this.timeLeft > 0) {
				this._timeLeft -= 1000;
			} else {
				this.finishTest();
			}
		}, 1000);

		this.userAnswers = new UserAnswers;
		this.userAnswers.testId = this.test.id;
		this.userAnswers.answers = [];
	}

	public setAnswer(questionId: number, answerId: number): void {
		let index = this.userAnswers.answers.findIndex(pair => pair.Key == questionId);
		if (index < 0) {
			this.userAnswers.answers.push({ Key: questionId, Value: answerId });
		}
		else {
			this.userAnswers.answers[index].Value = answerId;
		}
	}
	public getCheckedAnswer(questionId : number):number{
		let index = this.userAnswers.answers.findIndex(pair => pair.Key == questionId);
		if (index < 0) {
			return null;
		}
		return this.userAnswers.answers[index].Value;
	}

	public finishTest(): Observable<number> {
		this._isPassing = false;
		clearInterval(this.interval);
		let obs = this.sendResults(this.userAnswers);
		if(this.onFinish){
			this.onFinish(obs);
		}
		return obs;
	}

	private getFullTest(testId: number | string): Observable<FullTest> {
		return this.http.get<FullTest>(`${environment.apiUrl}/TestPassing/GetFullTest/${testId}`);
	}

	private sendResults(userAnswers: UserAnswers): Observable<number> {
		return this.http.post<number>(`${environment.apiUrl}/TestPassing/CheckUserAnswers`, userAnswers);
	}

	public getTestResult(resultId : number) : Observable<TestResult>{
		return this.http.get<TestResult>(`${environment.apiUrl}/TestPassing/GetResult/${resultId}`)
	}
}
