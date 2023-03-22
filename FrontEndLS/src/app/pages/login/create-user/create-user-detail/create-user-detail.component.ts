import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin, Observable } from 'rxjs';
import { Genders } from 'src/app/models/Gender';
import { PetTypes } from 'src/app/models/PetTypes';
import { Race } from 'src/app/models/Race';
import { selectCustom } from 'src/app/models/select-custom';
import { UserServicesService } from 'src/app/services/user-services.service';

@Component({
  selector: 'app-create-user-detail',
  templateUrl: './create-user-detail.component.html'
})

export class CreateUserDetailComponent {

  PetTypesSelect: selectCustom = {};

  PetTypes: PetTypes[] = [];
  Genders: Genders[] = [];
  Races: Race[] = [];

  selectedGenderId: number = 0;
  selectedPetTypeId: number = 0;
  selectedRaceId: number = 0;

  selectedPetTypeValue: string = '';

  constructor(private router: Router,
              private userService: UserServicesService
              ) { }

  ngOnInit(){
    console.log("prueba init")

    this.loadPetTypes();
    this.setSelectAreas('-',this.PetTypes,this.selectedPetTypeValue,false);

  }

  loadPetTypes(){
    console.log("jsfjjfdf")

    let obs: Observable<any>[] = [];
    obs.push(this.userService.getPetTypes());
    obs.push(this.userService.getGenders());

    forkJoin(obs).subscribe({
      next: response => {
        this.PetTypes = response[0].value;
        this.Genders = response[1].value;
        console.log(response)
      },
      error: err => {
        console.log(err);
      }
    });

  }

  onGenderChange() {
    console.log('Selected gender:', this.selectedGenderId);
    // Aquí puedes agregar tu lógica para manejar el evento de cambio de valor
  }

  onPetTypeChange2(){
    
  }
  onPetTypeChange(data: string) {
    console.log('Selected pet type:', this.selectedPetTypeId);
    

    this.userService.getRaceByPetTypeId(this.selectedPetTypeId).subscribe({
      next: response => {
        this.Races = response.value;
        console.log(this.Races)
      },
      error: err => {
        console.log(err);
      }
    });
    
    // Aquí puedes agregar tu lógica para manejar el evento de cambio de valor
  }

  onRaceChange(){
    console.log('Selected race:', this.selectedRaceId);
  }

  setSelectAreas(_defaultValue: string, _stringOptions: any[], _currentValue: string, _disabled){

    console.log("setSelectAreas")

    let areas: selectCustom = {
      title: 'Area',
      defaultValue: _defaultValue,
      stringOptions: _stringOptions,
      currentValue: _currentValue,
      disabled: _disabled
    }

    
    this.PetTypesSelect = areas;

    console.log("this.PetTypesSelect: ",this.PetTypesSelect)
  }
  
}
