import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  formModel = {
    Email: '',
    Password: ''
  }
  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    if (this.service.hastoken()) {
      this.router.navigateByUrl('/home');
    }
  }
  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(res => {
        if (res.success){
          this.service.addtoken(res.data);
          this.router.navigateByUrl('/home')
        } else {
          res.messages.forEach(element => {
            this.toastr.error(element);
          });
        }
      });
  }
}
