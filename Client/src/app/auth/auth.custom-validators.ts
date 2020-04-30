import { ValidationErrors, ValidatorFn, AbstractControl, Validators } from '@angular/forms';

export class CustomValidators {
	static patternValidator(regex: RegExp, error: ValidationErrors): ValidatorFn {
		return (control: AbstractControl): { [key: string]: any } => {
			if (!control.value) {
				// if control is empty return no error
				return null;
			}

			// test the value of the control against the regexp supplied
			const valid = regex.test(control.value);

			// if true, return no error (no error), else return error passed in the second parameter
			return valid ? null : error;
		};
	}

	static passwordMatchValidator(control: AbstractControl) {
		const password: string = control.get('password').value; // get password from our password form control
		const confirmPassword: string = control.get('confirmPassword').value; // get password from our confirmPassword form control
		// compare is the password math
		if (password !== confirmPassword) {
			// if they don't match, set an error in our confirmPassword form control
			control.get('confirmPassword').setErrors({ NoPasswordMatch: true });
		}
		
	}

	public static usernameValidators : ValidatorFn = Validators.compose([
		Validators.required,
		Validators.minLength(3),
		CustomValidators.patternValidator(/^[a-zA-Z\d-._@+]+$/, {
			validCharacters: true
		})
	]);

	public static passwordValidators : ValidatorFn = Validators.compose([
		Validators.required,
		// check whether the entered password has a number
		CustomValidators.patternValidator(/\d/, {
			hasNumber: true
		}),
		// check whether the entered password has upper case letter
		CustomValidators.patternValidator(/[A-Z]/, {
			hasCapitalCase: true
		}),
		// check whether the entered password has a lower case letter
		CustomValidators.patternValidator(/[a-z]/, {
			hasSmallCase: true
		}),
		// check whether the entered password has a special character
		CustomValidators.patternValidator(
			/[ !@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/,
			{
				hasSpecialCharacters: true
			}
		),
		Validators.minLength(8)
	]);
}
