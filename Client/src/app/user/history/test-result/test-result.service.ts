import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TestResult } from 'src/app/_models/tests/test-result';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class TestResultService {

	constructor(private http: HttpClient) { }

	public getTestResult(resultId: number): Observable<TestResult> {
		return this.http.get<TestResult>(`${environment.apiUrl}/TestPassing/GetResult/${resultId}`)
	}
}
