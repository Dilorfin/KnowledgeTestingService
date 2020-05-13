import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from "@angular/router";
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { TestsComponent } from './user/tests/tests.component';
import { ProfileComponent } from './user/profile/profile.component';
import { HistoryComponent } from './user/history/history.component';
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
import { TestPassingComponent } from './test-passing/test-passing.component';
import { StartAttemptComponent } from './test-passing/start-attempt/start-attempt.component';
import { TestResultComponent } from './user/history/test-result/test-result.component';
import { QuestionsComponent } from './test-passing/questions/questions.component';
import { TestPassingService } from './test-passing/test-passing.service';
import { TestEditingComponent } from './admin/admin-tests-management/test-editing/test-editing.component';


const adminRoutes: Routes = [
	{ path: '', redirectTo: 'tests-management', pathMatch:'full' },
	{ path: 'statistic', component: AdminStatisticComponent },
	{ path: 'users-management', component: AdminUsersManagementComponent },
	{ path: 'tests-management', component: AdminTestsManagementComponent },
	{ path: 'test-editing/:testId', component: TestEditingComponent }
]

const userRoutes: Routes = [
	{ path: '', redirectTo: 'tests', pathMatch: 'full' },
	{ path: 'tests', component: TestsComponent },
	{ path: 'profile', component: ProfileComponent },
	{ path: 'history', component: HistoryComponent },
	{ path: 'result/:resultId', component: TestResultComponent }
]

const authRoutes: Routes = [
	{ path: '', component: AuthLogInComponent },
	{ path: 'sign-up', component: AuthSignUpComponent }
]

const testPassingRoutes: Routes = [
	{ path: '', redirectTo: 'start', pathMatch: 'full' },
	{ path: 'start', component: StartAttemptComponent },
	{ path: 'questions',  component: QuestionsComponent }
]

const appRouts: Routes = [
	{ path: '', component: UserComponent, children: userRoutes, canActivate: [AuthGuard] },
	{ path: 'admin', component: AdminComponent, children: adminRoutes, canActivate: [AuthGuard] },
	{
		path: 'passing/:testId',
		component: TestPassingComponent,
		children: testPassingRoutes,
		canActivate: [AuthGuard]
	},
	{ path: 'auth', component: AuthComponent, children: authRoutes },
	{ path: '**', component: NotfoundComponent }
]

@NgModule({
	declarations: [
		AppComponent,
		TestsComponent,
		ProfileComponent,
		HistoryComponent,
		NotfoundComponent,
		AdminComponent,
		AdminStatisticComponent,
		AdminUsersManagementComponent,
		AdminTestsManagementComponent,
		UserComponent,
		AuthComponent,
		AuthLogInComponent,
		AuthSignUpComponent,
		TestPassingComponent,
		StartAttemptComponent,
		TestResultComponent,
		QuestionsComponent,
		TestEditingComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		ReactiveFormsModule,
		HttpClientModule,
		NgbModule,
		RouterModule.forRoot(appRouts)
	],
	providers: [
		{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
		{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

		AuthService, TestPassingService
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
