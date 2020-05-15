import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TestInfo } from 'src/app/_models/test-querying/test-info';
import { Items } from 'src/app/_helpers/pagination';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class TestsService {
	constructor(private http: HttpClient) { }

	getTestsInfo(offset: number, count: number, filter: string): Observable<Items<TestInfo>> {
		const params = new HttpParams()
			.set('offset', offset.toString())
			.set('count', count.toString())
			.set('filter', filter);
		return this.http.get<Items<TestInfo>>(`${environment.apiUrl}/TestQuerying/GetAllTestsInfo`, { params });
	}
}
