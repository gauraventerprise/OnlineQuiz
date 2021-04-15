import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { SubjectComponent } from './subject/subject.component';
import { SubjectShowSubComponent } from './subject/show-sub/show-sub.component';
import { SubjectAddEditSubComponent } from './subject/add-edit-sub/add-edit-sub.component';

import { CandidateComponent } from './candidate/candidate.component';
import { CandidateShowCandComponent } from './candidate/show-cand/show-cand.component';
import { CandidateAddEditCandComponent } from './candidate/add-edit-cand/add-edit-cand.component';

import { QuestionComponent } from './question/question.component';
import { QuestionShowQuesComponent } from './question/show-ques/show-ques.component';
import { QuestionAddEditQuesComponent } from './question/add-edit-ques/add-edit-ques.component';

import { ExamComponent } from './exam/exam.component';
import { ExamAddEditExamComponent } from './exam/add-edit-exam/add-edit-exam.component';
import { ExamShowExamComponent } from './exam/show-exam/show-exam.component';

import { SharedService } from './shared.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    SubjectComponent,
    SubjectShowSubComponent,
    SubjectAddEditSubComponent,
    QuestionComponent,
    QuestionShowQuesComponent,
    QuestionAddEditQuesComponent,
    CandidateComponent,
    CandidateShowCandComponent,
    CandidateAddEditCandComponent,
    ExamComponent,
    ExamAddEditExamComponent,
    ExamShowExamComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
