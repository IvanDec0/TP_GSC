import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Person } from 'src/app/models/person';
import { PeopleService } from 'src/app/services/people.service';

@Component({
  selector: 'app-add-people',
  templateUrl: './add-people.component.html',
  styleUrls: ['./add-people.component.scss']
})
export class AddPeopleComponent implements OnInit {

  personForm:FormGroup;

  constructor(builder:FormBuilder, private peopleService: PeopleService, private route:Router) {
    this.personForm=builder.group({
      name:['', [Validators.required]],
      phoneNumber:['', [Validators.pattern("[0-9 ]{10}")]],
      email:['', [Validators.email]],
    })

  }

  ngOnInit(): void {
  }

  addPerson()
  {
    const newPerson:Person= this.personForm.value;
    
    this.peopleService.AddPerson(newPerson)
    this.route.navigate(['/people']);
  }
}
