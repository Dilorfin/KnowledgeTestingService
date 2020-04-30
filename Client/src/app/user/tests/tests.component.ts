import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
	selector: 'app-tests',
	templateUrl: './tests.component.html',
	styleUrls: ['./tests.component.css']
})
export class TestsComponent implements OnInit {

	items: any[] = [

	];

	constructor(private router: Router) {}

	ngOnInit(): void {
		for (let index = 0; index < 15; index++) {
			this.items.push({
				Id: index,
				Title: "title",
				"Description": "description",
				"Time": "time"
			});
		}
	}
	openTestInfo(num: number): void {
		//this.router.navigate([""]);
		console.info(num);
	}
	empty(): void {
		
		console.info("shit");
	}
}
