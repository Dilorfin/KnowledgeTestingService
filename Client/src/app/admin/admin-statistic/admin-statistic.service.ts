import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Items } from 'src/app/_helpers/pagination';
import { TestGeneralStatistic } from 'src/app/_models/test-result/test-general-statistic';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class AdminStatisticService {

	constructor(private http: HttpClient) { }

	getAllTestsGeneralStatistic(offset: number, count: number): Observable<Items<TestGeneralStatistic>> {
		const params = new HttpParams()
			.set('offset', offset.toString())
			.set('count', count.toString());
		return this.http.get<Items<TestGeneralStatistic>>(`${environment.apiUrl}/TestResult/GetTestsGeneralStatistic`, { params });
	}
}
