import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/user';
import Validation from 'src/app/utils/validation';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css'],
   
})
export class UserRegisterComponent implements OnInit { 
  registrationForm:FormGroup = new FormGroup({
    userName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    confirmPassword: new FormControl(''),
    mobile: new FormControl('')
  });
  submitted = false;
  user:User | undefined;
  constructor(private formBuilder: FormBuilder,
    private alertify: AlertifyService) { }

  ngOnInit() {
    this.registrationForm = this.formBuilder.group(
      {
        userName: [null, [Validators.required]],
        email: [null, [Validators.required, Validators.email]],
        password: [null, [Validators.required, Validators.minLength(8)]],
        confirmPassword: [null, [Validators.required]],
        mobile: [null, [Validators.required, Validators.maxLength(10)]]
      },
      {
        Validators: [Validation.match('password', 'confirmPassword')]
      }
    );
  }
  get f(): { [key: string]: AbstractControl } {
    return this.registrationForm.controls;
  }
  userData(): User {
    return this.user = {
      userName: this.f['userName'].value,
      email: this.f['email'].value,
      password: this.f['password'].value,
      mobile: this.f['mobile'].value,
    }
  }
  onSubmit(): void {
    this.submitted = true;

    if (this.registrationForm.invalid) {
      this.alertify.error('Kindly provide the required fields');
      return;
    }
    this.alertify.success('Successfully Registered');
    console.log(JSON.stringify(this.registrationForm.value, null, 2));
  }
  onReset(): void {
    this.submitted = false;
    this.registrationForm.reset();
  }
}