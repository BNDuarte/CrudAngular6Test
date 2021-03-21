import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  readonly rootUrl = "http://localhost:5000";
  constructor(private http: HttpClient) { }

  savePerson(person) {
    return this.http.post(this.rootUrl + '/api/Person/Save', person);
  }

  getAllPersons() {
    return this.http.get(this.rootUrl + '/api/Person/get');
  }

  getPerson(id) {
    return this.http.get(this.rootUrl + '/api/Person/get/'+id);
  }

  deletePerson(id){
    return this.http.get(this.rootUrl + '/api/Person/delete/'+id);
  }
}
