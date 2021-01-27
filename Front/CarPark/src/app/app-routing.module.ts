import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomePageComponent } from './pages/home-page/home-page.component';
import { PesquisarComponent } from './pages/pesquisar/pesquisar.component';
import { CadastrarComponent } from './pages/cadastrar/cadastrar.component';
import { MeuPerfilComponent } from './pages/meu-perfil/meu-perfil.component'
import { LoginComponent } from './pages/login/login.component';
import { SignupComponent } from './pages/signup/signup.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomePageComponent },
  { path: 'pesquisar', component: PesquisarComponent },
  { path: 'cadastrar', component: CadastrarComponent },
  { path: 'perfil', component: MeuPerfilComponent },
  { path: 'signup', component: SignupComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
