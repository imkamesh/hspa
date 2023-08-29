import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { PropertyService } from './services/property.service';

import { AppComponent } from './app.component';
import { NavBarComponent } from "./nav-bar/nav-bar/nav-bar.component";
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  //{path: '', component: PropertyListComponent},
  {path: 'user/login', component: UserLoginComponent},
  {path: 'user/register', component: UserRegisterComponent}
]

@NgModule({
  declarations: [
    AppComponent, 
    NavBarComponent,
    UserLoginComponent,
    UserRegisterComponent
  ],
  imports: [
    BrowserModule,    
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule,
    HttpClientModule    
  ],
  providers: [PropertyService],
  bootstrap: [AppComponent],
})
export class AppModule {}
