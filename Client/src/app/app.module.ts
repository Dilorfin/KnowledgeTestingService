import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from "@angular/router";
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TestsComponent } from './user/tests/tests.component';
import { ProfileComponent } from './user/profile/profile.component';
import { WelcomeComponent } from './user/welcome/welcome.component';
import { StatisticComponent } from './user/statistic/statistic.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { AdminComponent } from './admin/admin.component';
import { AdminStatisticComponent } from './admin/admin-statistic/admin-statistic.component';
import { AdminUsersManagementComponent } from './admin/admin-users-management/admin-users-management.component';
import { AdminTestsManagementComponent } from './admin/admin-tests-management/admin-tests-management.component';
import { UserComponent } from './user/user.component';
import { AuthComponent } from './auth/auth.component';
import { AuthLogInComponent } from './auth/auth-log-in/auth-log-in.component';
import { AuthSignUpComponent } from './auth/auth-sign-up/auth-sign-up.component';
import { JwtInterceptor } from './_helpers/jwt.interceptor';
import { ErrorInterceptor } from './_helpers/error.interceptor';
import { AuthGuard } from './_helpers/auth.guard';
import { AuthService } from './auth/auth.service';
import { TestCardComponent } from './user/tests/test-card/test-card.component';


const adminRoutes: Routes = [
	{ path: '', component: AdminStatisticComponent },
	{ path: 'statistic', component: AdminStatisticComponent },
	{ path: 'users-management', component: AdminUsersManagementComponent },
	{ path: 'tests-management', component: AdminTestsManagementComponent }
]

const userRoutes: Routes = [
	{ path: '', component: WelcomeComponent },
	{ path: 'tests', component: TestsComponent },
	{ path: 'tests/:id', component: TestCardComponent },
	{ path: 'profile', component: ProfileComponent },
	{ path: 'statistic', component: StatisticComponent }
]

const authRoutes: Routes = [
	{ path: '', component: AuthLogInComponent },
	{ path: 'sign-up', component: AuthSignUpComponent }
]

const appRouts: Routes = [
	{ path: '', component: UserComponent, children: userRoutes, canActivate: [AuthGuard] },
	{ path: 'admin', component: AdminComponent, children: adminRoutes, canActivate: [AuthGuard] },
	{ path: 'auth', component: AuthComponent, children: authRoutes },
	{ path: '**', component: NotfoundComponent }
]

@NgModule({
	declarations: [
		AppComponent,
		TestsComponent,
		ProfileComponent,
		WelcomeComponent,
		StatisticComponent,
		NotfoundComponent,
		AdminComponent,
		AdminStatisticComponent,
		AdminUsersManagementComponent,
		AdminTestsManagementComponent,
		UserComponent,
		AuthComponent,
		AuthLogInComponent,
		AuthSignUpComponent,
		TestCardComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		ReactiveFormsModule,
		HttpClientModule,
		RouterModule.forRoot(appRouts)
	],
	providers: [
		{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
		{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

		AuthService
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
