import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from '@angular/forms';
import { Router } from '@angular/router';
import { RestService } from './rest.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb:FormBuilder, private rest: RestService, private router: Router) { }

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', [Validators.email ,Validators.required]],
    FullName: ['', Validators.required],
    Passwords:this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(8)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePass })
  });

  comparePass(fb:FormGroup)
  {
    let confirmPass = fb.get('ConfirmPassword');
    if (confirmPass.errors == null || 'passwordMismatch' in confirmPass.errors)
    {
      if (fb.get('Password').value != confirmPass.value)
      {
        confirmPass.setErrors({passwordMismatch: true});
      }else{
        confirmPass.setErrors(null)
      }
    }
  }

  register() {
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password,
      ConfirmPassword: this.formModel.value.Passwords.ConfirmPassword,
    };
    return this.rest.sendPostRequest('api/login/register', body);
  }

  login(formData: any) {
    return this.rest.sendPostRequest('api/login', formData);
  }

  hastoken(): boolean
  {
    return this.gettoken() != null;
  }

  gettoken(): string
  {
    return localStorage.getItem('token');
  }

  addtoken(token: string)
  {
    localStorage.setItem('token', token);
  }

  cleartoken()
  {
    localStorage.removeItem('token');
  }

  logout() {
    this.cleartoken();
    this.router.navigate(['/user/login']);
  }
}
