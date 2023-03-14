import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { CreateUserComponent } from './create-user/create-user.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  constructor(private router: Router,
              public dialog: MatDialog,) { }


  register(){
    const dialogRef = this.dialog.open(CreateUserComponent, {
      width: '40vw',
      height: '65vh',
      panelClass: 'dialog-register'
    });
  }
}


