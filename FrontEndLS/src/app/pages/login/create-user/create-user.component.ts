import { Component } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { forkJoin, Observable } from 'rxjs';
import { User } from 'src/app/models/User';
import { UserServicesService } from 'src/app/services/user-services.service';
import { CreateUserDetailComponent } from './create-user-detail/create-user-detail.component';


@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html'
})
export class CreateUserComponent {

  registroForm: UntypedFormGroup;

  constructor(private fb: UntypedFormBuilder,
              private router: Router,
              private userService: UserServicesService,
              public dialog: MatDialog) { 

    this.registroForm = this.fb.group({});
  }

  ngOnInit(){
    this.initForm()
  }

  initForm(){
    this.registroForm = this.fb.group(
      {
        email: ['', [Validators.required, Validators.email]],
        userName: ['', Validators.required],
        password: ['', [
            Validators.required,
            Validators.minLength(8),
            Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$')
          ]
        ],
        confirmPassword: ['', [
          Validators.required,
          Validators.minLength(8),
          Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$')

        ]],
      }
    );
  }

  

  createUser(){
    console.log(this.registroForm.value.email)
    console.log(this.registroForm.value.userName)
    console.log(this.registroForm.value.password)
    console.log(this.registroForm.value.confirmPassword)

    let userRegister: User = {
      email: this.registroForm.value.email,
      userName: this.registroForm.value.userName,
      password: this.registroForm.value.password
    }


    let obs: Observable<any>[] = [];
    obs.push(this.userService.registerUser(userRegister));

    forkJoin(obs).subscribe({
      next: response => {
        console.log(response)
        this.nextRegister();
      },
      error: err => {
        console.log(err);
      }
    });
  }

  nextRegister(){
    const dialogRef = this.dialog.open(CreateUserDetailComponent, {
      width: '40vw',
      height: '65vh',
      panelClass: 'dialog-register'
    });
  }

}
