import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/category';
import { Person } from 'src/app/models/person';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-add-categories',
  templateUrl: './add-categories.component.html',
  styleUrls: ['./add-categories.component.scss']
})
export class AddCategoriesComponent implements OnInit {

  CategoryForm:FormGroup;

  constructor(builder:FormBuilder, private categoryService: CategoryService, private route:Router) {
    this.CategoryForm=builder.group({
      description:['', [Validators.required]],
    })
  }

  ngOnInit(): void {
  }

  addCategory()
  {
    const newCategory:Category= this.CategoryForm.value;
    
    this.categoryService.AddCategory(newCategory)
    this.route.navigate(['/categories']);
  }

}
