import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EditTest } from 'src/app/_models/test-management/edit-test';

@Injectable({
	providedIn: 'root'
})
export class TestEditingService {

	constructor(private http: HttpClient) { }

	public getEditTest(testId: number | string): Observable<EditTest> {
		return this.http.get<EditTest>(`${environment.apiUrl}/TestManagement/GetEditTest/${testId}`);
	}

	public addTest(editTest :EditTest):Observable<void>{
		return this.http.post<void>(`${environment.apiUrl}/TestManagement/AddTest`, editTest);
	}
	public updateTest(editTest :EditTest):Observable<void>{
		return this.http.post<void>(`${environment.apiUrl}/TestManagement/UpdateTest`, editTest);
	}
}
