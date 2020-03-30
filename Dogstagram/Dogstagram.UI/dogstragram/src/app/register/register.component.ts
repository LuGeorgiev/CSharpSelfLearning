import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup

  constructor(private fb:FormBuilder, private authService: AuthService) { 
    this.registerForm = fb.group({
      'username' : ['', [Validators.required]],
      'password' : ['', [Validators.required]],
      'email' : ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
  }

  register(){
    //console.log(this.registerForm.value);
    this.authService.register(this.registerForm.value);
  }

  get username(){
    return this.registerForm.get('username');
  }

  get password(){
    return this.registerForm.get('password');
  }

  get email(){
    return this.registerForm.get('email');
  }
}
