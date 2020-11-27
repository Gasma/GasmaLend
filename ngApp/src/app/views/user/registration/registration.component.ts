import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html'
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmitRegistration() {
    this.service.register().subscribe(
      res => {
        if (res.success){
          this.service.formModel.reset();
          this.toastr.success("Usuario criado com sucesso!", "Sucesso!");
        } else {
          res.messages.forEach(element => {
            this.toastr.error(element, "Erro");
          });
        }
      });
  }
}
