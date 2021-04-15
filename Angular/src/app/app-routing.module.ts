import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SubjectComponent} from './subject/subject.component'
import { CandidateComponent} from './candidate/candidate.component'
import { QuestionComponent} from './question/question.component'
import { ExamComponent} from './exam/exam.component'


const routes: Routes = [
  {path:'subject',component:SubjectComponent},
  {path:'candidate',component:CandidateComponent},
  {path:'question',component:QuestionComponent},
  {path:'exam',component:ExamComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
