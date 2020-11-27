import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { HomeComponent } from './views/home/home.component';
import { LoginComponent } from './views/user/login/login.component';
import { RegistrationComponent } from './views/user/registration/registration.component';
import { UserComponent } from './views/user/user.component';

const routes: Routes = [
  {
    path:'', redirectTo:'user/login', pathMatch: 'full'
  },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  {
    path: 'home', component:HomeComponent, canActivate: [ AuthGuard ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
