import { FormGroup, FormBuilder, AbstractControl } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { CustomValidators } from '../auth.custom-validators';
import { AuthService } from '../auth.service';

@Component({
	selector: 'app-auth-log-in',
	templateUrl: './auth-log-in.component.html',
	styleUrls: ['./auth-log-in.component.css']
})
export class AuthLogInComponent implements OnInit {
	public formLogIn: FormGroup;
	public serverErrorMessage: string[];
	public loading: boolean = false;

	public get formControls(): { [key: string]: AbstractControl } {
		return this.formLogIn.controls;
	}

	constructor(private fb: FormBuilder, private authService: AuthService) {
		this.formLogIn = this.createLogInForm();
	}

	ngOnInit(): void { }

	createLogInForm(): FormGroup {
		return this.fb.group({
			username: [null, CustomValidators.usernameValidators],
			password: [null, CustomValidators.passwordValidators]
		});
	}

	submit() {
		this.loading = false;

		this.authService.login(this.formLogIn.value.username, this.formLogIn.value.password)
			.subscribe(() => {
				if (this.authService.isAuthorized) {
					location.reload();
				}
			},
				(error: HttpErrorResponse) => {
					this.serverErrorMessage = error.error;
					this.loading = false;
				}
			);
	}
}
