import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { PropertyService } from './services/property.service';
import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';

import { AppComponent } from './app.component';
import { NavBarComponent } from "./nav-bar/nav-bar/nav-bar.component";
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { RouterModule, Routes } from '@angular/router';
import { PropertyListComponent } from './property/property-list/property-list.component';

const appRoutes: Routes = [
  {path: '', component: PropertyListComponent},
  {path: 'user/login', component: UserLoginComponent},
  {path: 'user/register', component: UserRegisterComponent}
]

@NgModule({
  declarations: [
    AppComponent, 
    NavBarComponent,
    UserLoginComponent,
    UserRegisterComponent,
    PropertyListComponent
  ],
  imports: [
    BrowserModule,    
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule    
  ],
  providers: [PropertyService, AlertifyService, AuthService],
  bootstrap: [AppComponent],
})
export class AppModule {}
