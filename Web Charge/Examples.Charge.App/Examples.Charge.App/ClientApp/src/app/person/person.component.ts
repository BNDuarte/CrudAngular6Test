import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PersonService } from '../person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})

export class PersonComponent implements OnInit {

  constructor(private personService: PersonService) {
    this.getAllPersons();
  }

  headElements = ['ID', 'Name', 'Local phone', 'Cellphone',''];
  submitted = false;
  data:any;
  personForm: FormGroup
  Id: FormControl
  Name: FormControl
  Localphone:FormControl
  Cellphone:FormControl

  ngOnInit() {
    this.Name = new FormControl('', [Validators.required]);
    this.Id = new FormControl();
    this.Localphone=new FormControl('', [Validators.required]);
    this.Cellphone=new FormControl('', [Validators.required]);
    this.personForm = new FormGroup({
      Id: this.Id,
      Name: this.Name,
      Cellphone:this.Cellphone,
      Localphone:this.Localphone
    })
  }

  savePerson(person: any) {
    this.personService.savePerson(person).subscribe((data): any => {
      if (data) {
        alert("saved");
        this.getAllPersons();
      }
      this.personForm.reset();
    })
  }

  getAllPersons() {
   this.personService.getAllPersons().subscribe((data): any => {
     if (data) {
       this.data = data['data']['personDetailsObject'];
     }
     this.personForm.reset();
   })
  }

  deletePerson(id){
    this.personService.deletePerson(id).subscribe((data): any => {
      if (data) {
        alert("deleted");
        this.getAllPersons();
      }
      this.personForm.reset();
    })
  }

  editPerson(id){    
    this.personService.getPerson(id).subscribe((data): any => {
      if (data) {
        this.personForm.controls['Id'].setValue(data['data']['personObject']['id']);
        this.personForm.controls['Name'].setValue(data['data']['personObject']['name']);
        this.personForm.controls['Cellphone'].setValue(data['data']['personObject']['cellphone']);
        this.personForm.controls['Localphone'].setValue(data['data']['personObject']['localphone']);
      }
    })
  }
}
