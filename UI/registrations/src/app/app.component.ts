import { Component, OnInit } from '@angular/core';
import { RegistrationsService } from './service/registrations.service';
import { Registration } from './models/registrations.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'registrations';
  registrations : Registration[] = [];
  registration: Registration = {
    id: '',
    npiNumber: '',
    firstName: '',
    lastName: '', 
    email: '', 
    telephoneNumber: '', 
    businessAddress: ''
  }

  constructor(private registrationsService: RegistrationsService) {

  }

  ngOnInit(): void {
    this.getAllRegistrations();
  }

  getAllRegistrations(){
    this.registrationsService.getAllRegistrations()
    .subscribe(
      response => {
        this.registrations = response;
      }
    )
  }

  onSubmit(){

    if (this.registration.id === ''){
      this.registrationsService.addRegistration(this.registration)
      .subscribe(
        response => {
          this.getAllRegistrations();
          this.registration = {
            id: '',
            npiNumber: '',
            firstName: '',
            lastName: '', 
            email: '', 
            telephoneNumber: '', 
            businessAddress: ''
          };
        }
      );
    } else {
      this.updateRegistration(this.registration)
    }
  }

  deleteRegistration(id: string){
    this.registrationsService.deleteRegistration(id)
    .subscribe(
      response => {
        this.getAllRegistrations();
      }
    );
  }

  populateForm(registration: Registration){
    this.registration = registration;
  }

  updateRegistration(registration: Registration){
    this.registrationsService.updateRegistation(registration)
    .subscribe(
      response => {
        this.getAllRegistrations();
      }
    );
  }

}
