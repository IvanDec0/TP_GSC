import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { ListPeopleComponent } from './components/people/list-people/list-people.component';
import { AddPeopleComponent } from './components/people/add-people/add-people.component';
import { EditPeopleComponent } from './components/people/edit-people/edit-people.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './components/home/home.component';
import { ListCategoriesComponent } from './components/categories/list-categories/list-categories.component';
import { AddCategoriesComponent } from './components/categories/add-categories/add-categories.component';
import { EditCategoriesComponent } from './components/categories/edit-categories/edit-categories.component';
import { RegisterComponent } from './components/register/register.component';
import { interceptorProvider } from './services/auth-interceptor.service';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ListPeopleComponent,
    AddPeopleComponent,
    EditPeopleComponent,
    HomeComponent,
    ListCategoriesComponent,
    AddCategoriesComponent,
    EditCategoriesComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule, 
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule,
    FontAwesomeModule,
  ],
  providers: [interceptorProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
