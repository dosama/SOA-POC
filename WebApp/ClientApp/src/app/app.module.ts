import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ServiceBusSender } from './services/service-bus-sender.service';
import { ServiceBusSubscriber } from './services/service-bus-subscriber.service';
import { CourseDetailsComponent } from './course-details/course-details.component';
import { ExamDetailsComponent } from './exam-details/exam-details.component';
import { FetchCoursesComponent } from './fetch-courses/fetch-courses.component';
import { FetchExamsComponent } from './fetch-exams/fetch-exams.component';
import { FetchStudentsComponent } from './fetch-students/fetch-students.component';
import { FetchReportDataComponent } from './fetch-report-data/fetch-report-data.component';
import { StudentDetailsComponent } from './student-details/student-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CourseDetailsComponent,
    ExamDetailsComponent,
    FetchCoursesComponent,
    FetchExamsComponent,
    FetchStudentsComponent,
    StudentDetailsComponent,
    FetchReportDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
