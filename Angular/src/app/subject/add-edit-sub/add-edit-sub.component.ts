import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-sub',
  templateUrl: './add-edit-sub.component.html',
  styleUrls: ['./add-edit-sub.component.scss']
})

export class SubjectAddEditSubComponent implements OnInit  {

  constructor(private service:SharedService) { }

  subjectList:any=[];

  @Input() sub:any;
  subjectId:number=0;
  subjectName:string="";

  ngOnInit(): void {
    this.subjectId=this.sub.subjectId;
    this.subjectName=this.sub.subjectName;
  }

  refreshSubjectList(){
    this.service.getSubjectList().subscribe(data=>{this.subjectList = data;});
  }

  addSubject(){
    var val={SubjectName:this.subjectName};
    
    this.service.addSubject(val).subscribe(res=>{alert(res.toString());
      this.refreshSubjectList();
      }); 
    }

  updateSubject(){
    var val={SubjectId:this.subjectId, SubjectName:this.subjectName};

      this.service.updateSubject(val).subscribe(res=>{alert(res.toString());
      this.refreshSubjectList();
      });
    }
}