import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-cand',
  templateUrl: './add-edit-cand.component.html',
  styleUrls: ['./add-edit-cand.component.scss']
})
export class CandidateAddEditCandComponent implements OnInit {

  constructor(private service:SharedService) { }

  candidateList:any=[];

  @Input() cand:any;
  candidateId:number=0;
  password:string="";
  username:string="";
  firstName:string="";
  lastName:string="";
  address:string="";
  email:string="";
  mobile:string="";
  birthday:string="";
  gender:string="";
  photo:string="";
  
  ngOnInit(): void {
    this.candidateId=this.cand.candidateId;
    this.username=this.cand.username;
    this.password=this.cand.password;
    this.firstName=this.cand.firstName;
    this.lastName=this.cand.lastName;
    this.address=this.cand.address;
    this.email=this.cand.email;
    this.mobile=this.cand.mobile;
    this.birthday=this.cand.birthday;
    this.gender=this.cand.gender;
  }

  refreshCandidateList(){
    this.service.getCandidateList().subscribe(data=>{this.candidateList = data;});
  }

  addCandidate(){
    var val={Username:this.username, Password:this.password, FirstName:this.firstName,LastName:this.lastName,
      Address:this.address,Email:this.email,Mobile:this.mobile,Birthday:this.birthday,Gender:this.gender};

      this.service.addCandidate(val).subscribe(res=>{
        alert(res.toString());
      this.refreshCandidateList();
      }); 
    }

  updateCandidate(){
    var val={CandidateId:this.candidateId,Username:this.username, Password:this.password, FirstName:this.firstName, LastName:this.lastName,
      Address:this.address, Email:this.email, Mobile:this.mobile, Birthday:this.birthday, Gender:this.gender};

    this.service.updateCandidate(val).subscribe(res=>{
      alert(res.toString());
    this.refreshCandidateList();
    });
  }
}