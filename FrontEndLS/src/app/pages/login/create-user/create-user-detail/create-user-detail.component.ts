import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin, Observable } from 'rxjs';
import { UserServicesService } from 'src/app/services/user-services.service';

@Component({
  selector: 'app-create-user-detail',
  templateUrl: './create-user-detail.component.html'
})
export class CreateUserDetailComponent {

  constructor(private router: Router,
              private userService: UserServicesService
              ) { }

  ngOnInit(){
    this.loadPetTypes()
  }

  loadPetTypes(){

    let obs: Observable<any>[] = [];
    obs.push(this.userService.getPetTypes());

    forkJoin(obs).subscribe({
      next: response => {
        console.log(response)
      },
      error: err => {
        console.log(err);
      }
    });

  }
  
}
