import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-edit-categories',
  templateUrl: './edit-categories.component.html',
  styleUrls: ['./edit-categories.component.scss']
})
export class EditCategoriesComponent implements OnInit {

  CategoryForm:FormGroup;
  ActualCategory!:Category;
 
  constructor(builder:FormBuilder, private categoryService: CategoryService, private route:Router, private activateRouter: ActivatedRoute) {
    this.CategoryForm=builder.group({
      description:['', [Validators.required]],
    })
  }

  ngOnInit(): void {
    const id = this.activateRouter.snapshot.paramMap.get("id")!;
    console.log(id);
    this.categoryService.GetCategory(id).subscribe(
      res=>{this.ActualCategory=res;
            this.CategoryForm.patchValue(this.ActualCategory);},
      err=>console.log(err)
    );
  }

  editCategory()
  {
    const editedPerson:Category = { id:this.ActualCategory?.id, ...this.CategoryForm.value } ;
    this.categoryService.EditCategory(editedPerson);
    this.route.navigate(['/categories']);
  }

}
