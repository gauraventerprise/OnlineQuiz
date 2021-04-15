import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class SharedService {
readonly APIUri = "https://localhost:44358/api";

  constructor(private http:HttpClient) { }

  getSubjectList():Observable<any[]>{
    return this.http.get<any>(this.APIUri+'/Subject');
  }

  addSubject(val:any){
    return this.http.post(this.APIUri+'/Subject',val);
  }
  
  updateSubject(val:any){
    return this.http.put(this.APIUri+'/Subject',val);
  }

  deleteSubject(val:any){
    return this.http.delete(this.APIUri+'/Subject/'+val);
  }


  getCandidateList():Observable<any[]>{
    return this.http.get<any>(this.APIUri+'/Registration');
  }

  addCandidate(val:any){
    return this.http.post(this.APIUri+'/Registration',val);
  }

  updateCandidate(val:any){
    return this.http.put(this.APIUri+'/Registration', val);
  }

  deleteCandidate(val:any){
    return this.http.delete(this.APIUri+'/Registration/'+val);
  }


  getQuestionList():Observable<any[]>{
    return this.http.get<any>(this.APIUri+'/Question');
  }

  addQuestion(val:any){
    return this.http.post(this.APIUri+'/Question',val);
  }

  updateQuestion(val:any){
    return this.http.put(this.APIUri+'/Question', val);
  }

  deleteQuestion(val:any){
    return this.http.delete(this.APIUri+'/Question/'+val);
  }

  getQuestionsBySubject(id:number):Observable<any[]>{
    return this.http.get<any>(this.APIUri+'/Exam/'+id);
  }

}