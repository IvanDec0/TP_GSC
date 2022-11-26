import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Person } from 'src/app/models/person';
import { PeopleService } from 'src/app/services/people.service';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { faRotate } from '@fortawesome/free-solid-svg-icons';
import { faHouse } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-list-people',
  templateUrl: './list-people.component.html',
  styleUrls: ['./list-people.component.scss']
})
export class ListPeopleComponent implements OnInit, OnChanges {

  faTrash = faTrash;
  faPlus = faPlus;
  faEdit = faEdit;
  faRotate = faRotate;
  faHouse = faHouse;
  people:Person[]= [];
  constructor(private peopleService: PeopleService) { }

  ngOnInit(): void {
  this.listPeople();
    }
  
  ngOnChanges(changes: SimpleChanges): void {
    console.log("Changes in ", changes);
  }

  listPeople()
  {
    this.peopleService.GetPeople().subscribe(
      res=>{this.people=res},
      err=>console.log(err)
    )
  }

  ReloadList(){
    this.listPeople();
  }

  delete(id:string)
  {
    this.peopleService.DeletePerson(id)
    this.people = this.people.filter(person => person.id !== id);
  }
}