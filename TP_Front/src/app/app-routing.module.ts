import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AddPeopleComponent } from './components/people/add-people/add-people.component';
import { EditPeopleComponent } from './components/people/edit-people/edit-people.component';
import { ListPeopleComponent } from './components/people/list-people/list-people.component';
import { AuthGuardGuard } from './guard/auth-guard.guard';
import { HomeComponent } from './components/home/home.component';
import { AddCategoriesComponent } from './components/categories/add-categories/add-categories.component';
import { EditCategoriesComponent } from './components/categories/edit-categories/edit-categories.component';
import { ListCategoriesComponent } from './components/categories/list-categories/list-categories.component';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'people', component: ListPeopleComponent, canActivate: [AuthGuardGuard] },
  { path: 'people/add', component: AddPeopleComponent, canActivate: [AuthGuardGuard] },
  { path: 'people/edit/:id', component: EditPeopleComponent, canActivate: [AuthGuardGuard] },
  { path: 'categories', component: ListCategoriesComponent, canActivate: [AuthGuardGuard] },
  { path: 'categories/add', component: AddCategoriesComponent, canActivate: [AuthGuardGuard] },
  { path: 'categories/edit/:id', component: EditCategoriesComponent, canActivate: [AuthGuardGuard] },
  {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: '**', redirectTo:"home"}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
