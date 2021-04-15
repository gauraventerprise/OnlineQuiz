import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service'

@Component({
  selector: 'app-show-exam',
  templateUrl: './show-exam.component.html',
  styleUrls: ['./show-exam.component.scss']
})
export class ExamShowExamComponent implements OnInit {

  constructor(private service:SharedService) { }

  subjectList:any=[];
  questionList:any=[];

  selectedSubject:any;
  ModalTitle:string="";
  ActivateExamComp:boolean=false;
  exam:any;

  ngOnInit(): void {
    this.refreshSubjectList();
  }

  refreshSubjectList(){
    this.service.getSubjectList().subscribe(data=>{this.subjectList = data;});
  }

  refreshQuestionList(){
    this.service.getQuestionsBySubject(this.selectedSubject).subscribe(data=>{this.questionList = data;});
    // this.exam=this.questionList;
  }

  closeClick(){
    this.ActivateExamComp=false;
    // this.refreshSubjectList();
  }

  startExam(item:number)
  {
    // this.exam=item;
    this.ModalTitle="Start Exam";
    this.ActivateExamComp=true;

    this.refreshQuestionList();
  }
}
