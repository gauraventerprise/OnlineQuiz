import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import {interval} from 'rxjs'
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-add-edit-exam',
  templateUrl: './add-edit-exam.component.html',
  styleUrls: ['./add-edit-exam.component.scss']
})
export class ExamAddEditExamComponent implements OnInit {

  constructor(private service:SharedService) { }

  timerCount:any=0;
  subjectList:any=[];
  questionList:any=[];

  @Input() exam:any;
  questionId:number=0;
  question1:string="";
  option1:string="";
  option2:string="";
  option3:string="";
  option4:string="";
  answer:string="";
  complexity:string="";

  ngOnInit(): void {
    this.startCountdown(120); // we can set timer from here
    // this.questionId=this.exam.questionId;
    // this.question1=this.exam.question1;
    // this.option1=this.exam.option1;
    // this.option2=this.exam.option2;
    // this.option3=this.exam.option3;
    // this.option4=this.exam.option4;
    // this.answer=this.exam.answer;
    // this.complexity=this.exam.complexity;

    this.addQuestion();
  }
 
  addQuestion(){
    var val={Question1:this.question1, Option1:this.option1,Option2:this.option2,Option3:this.option3,Option4:this.option4,
      Answer:this.answer,Complexity:this.complexity};

      // this.service.addQuestion(val).subscribe(res=>{
      //   alert(res.toString());
      // this.refreshQuestionList();
      // }); 
    }


  submit()
  {
    // Are you sure if timer is not finish
    // redirect to from page
    console.log('SUBMIT');
  }

  // Timer functionality
  startCountdown(counter:any) {
    const interval = setInterval(() => {
      this.timerCount=counter;
      counter--;
        
      if (counter < 0 ) {
        clearInterval(interval);
        this.submit();
      }
    }, 1000);
  };
}