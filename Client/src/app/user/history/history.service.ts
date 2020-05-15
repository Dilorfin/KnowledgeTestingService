import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TestResult } from 'src/app/_models/test-result/test-result';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Items } from 'src/app/_helpers/pagination';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class HistoryService {

	constructor(private http : HttpClient) { }

	getAllResults(offset : number, count:number) : Observable<Items<TestResult>>{
		const params = new HttpParams()
			.set('offset', offset.toString())
			.set('count', count.toString());
		return this.http.get<Items<TestResult>>(`${environment.apiUrl}/TestResult/GetAllUserResults`, {params});
	}
}
