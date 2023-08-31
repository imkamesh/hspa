import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  staticUsers:any[];

constructor() { 
  this.staticUsers = [
    {
      "userName" : "imkamesh",
      "password" : "kamesh@123"
    },
    {
      "userName" : "imkriyaan",
      "password" : "kriyaan@123"
    },
    {
      "userName" : "imveenaa",
      "password" : "veenaa@123"
    }
  ];

}

authUser(user: any) {
  let userArray = [];
  if(this.staticUsers && this.staticUsers.length > 0){
    userArray = this.staticUsers;
  }
  return userArray.find((p: any) => p.userName === user.userName &&
    p.password === user.password);
}

}
