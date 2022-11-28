import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginUser } from 'src/app/models/login-user';
import { AuthService } from 'src/app/services/auth.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerUser:FormGroup;

  constructor(
    private builder:FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { 
    this.registerUser=builder.group({
      UserName:['',Validators.required],
      Password:['',Validators.required]
    })
  }

  ngOnInit() {
  }

  onRegister(): void {
    let user:LoginUser = this.registerUser.value
    this.authService.register(user).subscribe();
    this.router.navigate(['/home']);
}
}
