import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from 'src/app/models/person';
import { PeopleService } from 'src/app/services/people.service';

@Component({
  selector: 'app-edit-people',
  templateUrl: './edit-people.component.html',
  styleUrls: ['./edit-people.component.scss']
})
export class EditPeopleComponent implements OnInit {

  personForm:FormGroup;
  ActualPerson!:Person;

  constructor(builder:FormBuilder, private peopleService: PeopleService, private route:Router, private activateRouter: ActivatedRoute) {
    this.personForm=builder.group({
      name:['', [Validators.required]],
      phoneNumber:['', [Validators.pattern("[0-9 ]{10}")]],
      email:['', [Validators.email]],
    })

  }

  ngOnInit(): void {
    const id = this.activateRouter.snapshot.paramMap.get("id")!;
    console.log(id);
    this.peopleService.GetPerson(id).subscribe(
      res=>{this.ActualPerson=res;
            this.personForm.patchValue(this.ActualPerson);},
      err=>console.log(err)
    );
  }

  editPerson()
  {
    const editedPerson:Person = { id:this.ActualPerson?.id, ...this.personForm.value } ;
    this.peopleService.EditPerson(editedPerson);
    this.route.navigate(['/people']);
  }
}
