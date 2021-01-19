import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class UserService {
  readonly BaseURI = 'http://localhost:57092/api';
  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) { }
 

  formModel = this.fb.group({
    FirstName: ['', Validators.required],
    Email: ['', [Validators.required, Validators.email]],
    LastName: ['', Validators.required]
  });

  

  register() {
    var body = {
      FirstName: this.formModel.value.FirstName,
      Email: this.formModel.value.Email,
      LastName: this.formModel.value.LastName
    };
    return this.http.post(this.BaseURI + '/ApplicationUser/Register', body);
  }
  
  login(formData) {
    return this.http.post(this.BaseURI + '/ApplicationUser/Login', formData);
  }

  logout() {
    localStorage.removeItem('email');
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  } 
  
  setLanguage(lang = "en"){
    localStorage.setItem('language', lang);
  }
}