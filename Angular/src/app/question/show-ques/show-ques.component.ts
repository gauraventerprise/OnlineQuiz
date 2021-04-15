import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service'

@Component({
  selector: 'app-show-ques',
  templateUrl: './show-ques.component.html',
  styleUrls: ['./show-ques.component.scss']
})
export class QuestionShowQuesComponent implements OnInit {

  constructor(private service:SharedService) { }

  subjectList:any=[];
  questionList:any=[];

  ModalTitle:string="";
  ActivateAddEditQuesComp:boolean=false;
  ques:any;

  ngOnInit(): void {
    this.refreshQuestionList();
    this.refreshSubjectList();
  }

  refreshQuestionList(){
    this.service.getQuestionList().subscribe(data=>{this.questionList= data;});
  }

  refreshSubjectList(){
    this.service.getSubjectList().subscribe(data=>{this.subjectList = data;});
  }

  addClick()
  {
    this.ques={
      questionId:0,
      question1:"",
      option1:"",
      option2:"",
      option3:"",
      option4:"",
      answer:"",
      subjectId:0,
      complexity:""
    }
    this.ModalTitle="Add Question";
    this.ActivateAddEditQuesComp=true;
  }

  closeClick(){
    this.ActivateAddEditQuesComp=false;
    this.refreshQuestionList();
  }

  editClick(item:any){
    this.ques=item;
    this.ModalTitle="Edit Question";
    this.ActivateAddEditQuesComp=true;
  }

  deleteClick(item:any){
    if(confirm('Are you sure??'))
    {
      this.service.deleteQuestion(item.questionId).subscribe(data=>{
         alert(data.toString());
         this.refreshQuestionList();
       })
     }
   }
}
