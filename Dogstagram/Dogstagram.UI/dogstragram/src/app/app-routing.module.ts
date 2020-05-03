import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CreatepostComponent } from './createpost/createpost.component';
import { AuthGuardService } from './services/auth-guard.service';
import { ListDogsComponent } from './list-dogs/list-dogs.component';
import { DetailsDogComponent } from './details-dog/details-dog.component';
import { EditDogComponent } from './edit-dog/edit-dog.component';


const routes: Routes = [
  { path:'login', component: LoginComponent},
  { path:'register', component: RegisterComponent},
  { path:'create', component: CreatepostComponent , canActivate: [AuthGuardService] },
  { path:'dogs', component: ListDogsComponent, canActivate : [AuthGuardService]  },
  { path:'dogs/:id',component: DetailsDogComponent, canActivate: [AuthGuardService] },
  { path:'dogs/:id/edit', component: EditDogComponent, canActivate:[AuthGuardService] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
