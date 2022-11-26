import { Component, OnInit } from '@angular/core';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { faRotate } from '@fortawesome/free-solid-svg-icons';
import { faHouse } from '@fortawesome/free-solid-svg-icons';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-list-categories',
  templateUrl: './list-categories.component.html',
  styleUrls: ['./list-categories.component.scss']
})
export class ListCategoriesComponent implements OnInit {

  faTrash = faTrash;
  faPlus = faPlus;
  faEdit = faEdit;
  faRotate = faRotate;
  faHouse = faHouse;
  categories:Category[]= [];
  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
  this.listCategories();
    }

    listCategories()
  {
    this.categoryService.GetCategories().subscribe(
      res=>{this.categories=res},
      err=>console.log(err)
    )
  }

  ReloadList(){
    this.listCategories();
  }

  delete(id:string)
  {
    this.categoryService.DeleteCategory(id)
    this.categories = this.categories.filter(category => category.id !== id);
  }

}
