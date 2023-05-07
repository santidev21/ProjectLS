import { Component, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin, Observable } from 'rxjs';
import { Genders } from 'src/app/models/Gender';
import { PetTypes } from 'src/app/models/PetTypes';
import { Race } from 'src/app/models/Race';
import { selectCustom } from 'src/app/models/select-custom';
import { AwsServicesService } from 'src/app/services/aws-services.service';
import { UserServicesService } from 'src/app/services/user-services.service';


@Component({
  selector: 'app-create-user-detail',
  templateUrl: './create-user-detail.component.html'
})

export class CreateUserDetailComponent {
  @ViewChild('fileInput') fileInput: ElementRef;

  PetTypesSelect: selectCustom = {};
  GendersSelect: selectCustom = {};
  RacesSelect: selectCustom = {};

  PetTypes: PetTypes[] = [];
  petTypesName: any[] = [];
  Genders: Genders[] = [];
  Races: Race[] = [];

  selectedGenderId: number = 0;
  selectedPetTypeId: number = 0;
  selectedRaceId: number = 0;

  selectedPetTypeValue: string = '';
  selectedGenderValue: string = '';
  selectedRaceValue: string = '';

  disabledBtnChangeImage: boolean = true;

  defaultPic: string = '../../../../../assets/img_default.png';

  fileToUpload: File;

  constructor(private router: Router,
              private userService: UserServicesService,
              private awsService: AwsServicesService
              ) { }

  ngOnInit(){

    this.loadPetTypes();
  }

  loadPetTypes(){

    let obs: Observable<any>[] = [];
    obs.push(this.userService.getPetTypes());
    obs.push(this.userService.getGenders());

    forkJoin(obs).subscribe({
      next: response => {
        this.PetTypes = response[0].value;
        this.Genders = response[1].value;
        this.setSelectPet('-',this.PetTypes,this.selectedPetTypeValue,false);
        this.setSelectGender('-',this.Genders,this.selectedGenderValue,false);
        this.setSelectRace('-',this.Races,this.selectedRaceValue,false);
      },
      error: err => {
        console.log(err);
      }
    });
  }

  onGenderChange(data: string) {
    const gender = this.Genders.find(gender => gender.genderName === data);

    this.selectedGenderId = gender === undefined ? 0 : gender.id;
  }

  onPetTypeChange(data: string) {
    const pet = this.PetTypes.find(pet => pet.petTypeName === data);
    
    this.selectedPetTypeId = pet === undefined ? 0 : pet.id;

    if(pet !==undefined){
      this.disabledBtnChangeImage = false;

      this.defaultPic = pet.defaultPetPic;
    
      this.userService.getRaceByPetTypeId(pet.id).subscribe({
        next: response => {
          this.Races = response.value;
          this.setSelectRace('-',this.Races,this.selectedRaceValue,false);
        },
        error: err => {
          console.log(err);
        }
      });
    }
    else{
      this.disabledBtnChangeImage = true;
    }

  }

  onRaceChange(data: string){
    const race = this.Races.find(race => race.raceName === data);
    this.selectedRaceId = race === undefined ? 0 : race.id;
  }

  setSelectPet(_defaultValue: string, _stringOptions: any[], _currentValue: string, _disabled){
    const petTypeNamesArray = _stringOptions.map(option => option.petTypeName);

    let petType: selectCustom = {
      title: '',
      defaultValue: _defaultValue,
      stringOptions: petTypeNamesArray,
      currentValue: _currentValue,
      disabled: _disabled
    }
    this.PetTypesSelect = petType;
  }
  
  setSelectGender(_defaultValue: string, _stringOptions: any[], _currentValue: string, _disabled){
    
    const gendersArray = _stringOptions.map(option => option.genderName);

    let genders: selectCustom = {
      title: '',
      defaultValue: _defaultValue,
      stringOptions: gendersArray,
      currentValue: _currentValue,
      disabled: _disabled
    }
    this.GendersSelect = genders;
  }

  setSelectRace(_defaultValue: string, _stringOptions: any[], _currentValue: string, _disabled){
    
    const racesArray = _stringOptions.map(option => option.raceName);

    let races: selectCustom = {
      title: '',
      defaultValue: _defaultValue,
      stringOptions: racesArray,
      currentValue: _currentValue,
      disabled: _disabled
    }
    this.RacesSelect = races;
  }

  openFileDialog() {
    this.fileInput.nativeElement.click();
  }
  
  onFileSelected(event: any) {

  }

  handleFileInput(event: any) {

    const files: FileList = event.target.files;
    this.fileToUpload = files.item(0);
    
    this.uploadImage();
  }

  

  uploadImage(){
    const formData: FormData = new FormData();

    formData.append('file', this.fileToUpload);

    this.awsService.savePhoto(formData).subscribe({
      next: response => {
        this.defaultPic = response.value;
      },
      error: err => {
        console.log(err);
      }
    });

    
  }
  
}
