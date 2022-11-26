import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginUser } from 'src/app/models/login-user';
import { AuthService } from 'src/app/services/auth.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginUser:FormGroup;

  constructor(
    private builder:FormBuilder,
    private tokenService: TokenService,
    private authService: AuthService,
    private router: Router
  ) { 
    this.loginUser=builder.group({
      UserName:['',Validators.required],
      Password:['',Validators.required]
    })
  }

  ngOnInit() {
  }

  onLogin(): void {
    let user:LoginUser = this.loginUser.value
    this.authService.login(user).subscribe({
      next: (data: any) => {
      this.tokenService.setToken(data);
      this.router.navigate(['/home']);
      }
    });
    
    // this.authService.login(user).subscribe(
    //   {
    //   next: (resp: any) => {
    //     console.log(resp);
    //     this.tokenService.setToken(resp.token);
    //     this.router.navigate(['/people']);
    //   },
    //   error: err => {
    //     console.log(err);
    //   }
    // }
    //);
  }


}
