import { Component, OnInit } from '@angular/core';
import { TokenService } from 'src/app/services/token.service';
import { faPeopleGroup } from '@fortawesome/free-solid-svg-icons';
import { faTag } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  
  isLoged = false;
  faPeopleGroup = faPeopleGroup;
  faTag = faTag;
  constructor(private tokenService: TokenService) { }

  ngOnInit(): void {
    this.isLoged = this.tokenService.isLogged();
  }

  logOut(){
    this.tokenService.logOut();
    this.isLoged = false;
  }

}
