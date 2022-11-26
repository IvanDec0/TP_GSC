import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, of, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  private GlobalUrl=`${environment.apiBack}/people`

  constructor(private http:HttpClient) { }

  GetPeople():Observable<Person[]>{  
    return this.http.get<Person[]>(this.GlobalUrl);
  }

  GetPerson(id:string):Observable<Person>{
    return this.http.get<Person>(`${this.GlobalUrl}/${id}`);
  }

  AddPerson(newPerson:Person){
    this.http.post(this.GlobalUrl, newPerson).subscribe();
  }

  DeletePerson(id:string){
    this.http.delete(`${this.GlobalUrl}/${id}`).subscribe();
  }

  EditPerson(person:Person){
    this.http.put(`${this.GlobalUrl}/${person.id}`, person).subscribe();
  }
}