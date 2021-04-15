import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-ques',
  templateUrl: './add-edit-ques.component.html',
  styleUrls: ['./add-edit-ques.component.scss']
})
export class QuestionAddEditQuesComponent implements OnInit {

  constructor(private service:SharedService) { 
  }

  subjectList:any=[];
  questionList:any=[];

  
  @Input() ques:any;
  questionId:number=0;
  question1:string="";
  option1:string="";
  option2:string="";
  option3:string="";
  option4:string="";
  answer:string="";
  // subjectId:string="";
  complexity:string="";
  
  ngOnInit(): void {
    this.refreshSubjectList();

    this.questionId=this.ques.questionId;
    this.question1=this.ques.question1;
    this.option1=this.ques.option1;
    this.option2=this.ques.option2;
    this.option3=this.ques.option3;
    this.option4=this.ques.option4;
    this.answer=this.ques.answer;
    // this.subjectId=this.ques.subjectId;
    this.complexity=this.ques.complexity;
  }

  refreshQuestionList(){
    this.service.getQuestionList().subscribe(data=>{this.questionList = data;});
  }

  refreshSubjectList(){
    this.service.getSubjectList().subscribe(data=>{this.subjectList = data;});
  }

  addQuestion(){
    var val={Question1:this.question1, Option1:this.option1,Option2:this.option2,Option3:this.option3,Option4:this.option4,
      Answer:this.answer, Complexity:this.complexity};

      this.service.addQuestion(val).subscribe(res=>{
        alert(res.toString());
      this.refreshQuestionList();
      }); 
    }

  updateQuestion(){
    var val={QuestionId:this.questionId, Question1:this.question1, Option1:this.option1,Option2:this.option2,Option3:this.option3,Option4:this.option4,
      Answer:this.answer,Complexity:this.complexity};

    this.service.updateQuestion(val).subscribe(res=>{
      alert(res.toString());
    this.refreshQuestionList();
    });
  }
}