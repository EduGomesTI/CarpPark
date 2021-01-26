import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Components
import { HeadbarComponent } from './components/Shared/headbar/headbar.component';
import { SubMenuComponent } from './components/Shared/sub-menu/sub-menu.component';
import { FooterComponent } from './components/Shared/footer/footer.component';

// Pages
import { PesquisarComponent } from './pages/pesquisar/pesquisar.component';
import { CadastrarComponent } from './pages/cadastrar-pf/cadastrar-pf.component';
import { MeuPerfilComponent } from './pages/meu-perfil/meu-perfil.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { LoginComponent } from './pages/login/login.component';
import { SignupComponent } from './pages/signup/signup.component';
import { CadastrarPjComponent } from './pages/cadastrar-pj/cadastrar-pj.component';
import { PesquisarPfComponent } from './pages/pesquisar-pf/pesquisar-pf.component';
import { PesquisarPjComponent } from './pages/pesquisar-pj/pesquisar-pj.component';

@NgModule({
  declarations: [
    AppComponent,
    HeadbarComponent,
    SubMenuComponent,
    FooterComponent,
    PesquisarComponent,
    CadastrarComponent,
    MeuPerfilComponent,
    HomePageComponent,
    LoginComponent,
    SignupComponent,
    CadastrarPjComponent,
    PesquisarPfComponent,
    PesquisarPjComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
