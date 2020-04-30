import { FormGroup, Validators, FormBuilder, AbstractControl } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { CustomValidators } from '../auth.custom-validators';
import { AuthService } from '../auth.service';

@Component({
	selector: 'app-auth-sign-up',
	templateUrl: './auth-sign-up.component.html',
	styleUrls: ['./auth-sign-up.component.css']
})
export class AuthSignUpComponent implements OnInit {
	public formSignUp: FormGroup;
	public serverErrorMessage: { description: string, code: string }[];
	public loading: boolean = false;

	public get formControls(): { [key: string]: AbstractControl } {
		return this.formSignUp.controls;
	}

	constructor(private fb: FormBuilder, private authService: AuthService) {
		this.formSignUp = this.createSignUpForm();
	}

	ngOnInit(): void { }

	createSignUpForm(): FormGroup {
		return this.fb.group({
			username: [null, [CustomValidators.usernameValidators]],
			email: [null, [Validators.email]],
			password: [null, CustomValidators.passwordValidators],
			confirmPassword: [null, [Validators.required]]
		},
			{
				// check whether our password and confirm password match
				validator: CustomValidators.passwordMatchValidator
			}
		);
	}

	submit() {
		this.loading = true;
		this.authService.register(this.formSignUp.value.username,
			this.formSignUp.value.password,
			this.formSignUp.value.email)
			.subscribe(() => {
				this.login(this.formSignUp.value.username, this.formSignUp.value.password);
			},
				(error: HttpErrorResponse) => {
					this.serverErrorMessage = error.error;
					this.loading = false;
				}
			);
	}

	private login(username: string, password: string) {
		this.authService.login(username, password)
			.subscribe(() => {
				location.reload();
			});
	}
}
