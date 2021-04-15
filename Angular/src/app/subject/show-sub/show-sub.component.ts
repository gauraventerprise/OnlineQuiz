import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service'

@Component({
  selector: 'app-show-sub',
  templateUrl: './show-sub.component.html',
  styleUrls: ['./show-sub.component.scss']
})
export class SubjectShowSubComponent implements OnInit {

  constructor(private service:SharedService) { }

  subjectList:any=[];

  ModalTitle:string="";
  ActivateAddEditSubComp:boolean=false;
  sub:any;

  ngOnInit(): void {
    this.refreshSubjectList();
  }

  refreshSubjectList(){
    this.service.getSubjectList().subscribe(data=>{this.subjectList = data;});
  }

  addClick()
  {
    this.sub={
      subjectId:0,
      subjectName:""
    }
    this.ModalTitle="Add Subject";
    this.ActivateAddEditSubComp=true;
  }

  closeClick(){
    this.ActivateAddEditSubComp=false;
    this.refreshSubjectList();
  }

  editClick(item:any){
    this.sub=item;
    this.ModalTitle="Edit Subject";
    this.ActivateAddEditSubComp=true;
  }
 
  deleteClick(item:any){
   if(confirm('Are you sure??'))
   {
     this.service.deleteSubject(item.subjectId).subscribe(data=>{
        alert(data.toString());
        this.refreshSubjectList();
      })
    }
  }
}