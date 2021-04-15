import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service'

@Component({
  selector: 'app-show-cand',
  templateUrl: './show-cand.component.html',
  styleUrls: ['./show-cand.component.scss']
})
export class CandidateShowCandComponent implements OnInit {

  constructor(private service:SharedService) { }

  candidateList:any=[];

  ModalTitle:string="";
  ActivateAddEditCandComp:boolean=false;
  cand:any;

  ngOnInit(): void {
    this.refreshCandidateList();
  }

  refreshCandidateList(){
    this.service.getCandidateList().subscribe(data=>{this.candidateList= data;});
  }

  addClick()
  {
    this.cand={
      candidateId:0,
      username:"",
      password:"",
      firstName:"",
      lastName:"",
      address:"",
      email:"",
      mobile:"",
      birthday:"",
      gender:"",
      photo:"anonymous.png"
    }
    this.ModalTitle="Add Candidate";
    this.ActivateAddEditCandComp=true;
  }

  closeClick(){
    this.ActivateAddEditCandComp=false;
    this.refreshCandidateList();
  }

  editClick(item:any){
    this.cand=item;
    this.ModalTitle="Edit Candidate";
    this.ActivateAddEditCandComp=true;
  }

  deleteClick(item:any){
    if(confirm('Are you sure??'))
    {
      this.service.deleteCandidate(item.candidateId).subscribe(data=>{
         alert(data.toString());
         this.refreshCandidateList();
       })
     }
   }
}