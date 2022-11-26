import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category } from '../models/category';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private GlobalUrl=`${environment.apiBack}/categories`

  constructor(private http:HttpClient) { }

  GetCategories():Observable<Category[]>{  
    return this.http.get<Category[]>(this.GlobalUrl);
  }

  GetCategory(id:string):Observable<Category>{
    return this.http.get<Category>(`${this.GlobalUrl}/${id}`);
  }

  AddCategory(newCategory:Category){
    this.http.post(this.GlobalUrl, newCategory).subscribe();
  }

  DeleteCategory(id:string){
    this.http.delete(`${this.GlobalUrl}/${id}`).subscribe();
  }

  EditCategory(category:Category){
    this.http.put(`${this.GlobalUrl}/${category.id}`, category).subscribe();
  }
}
