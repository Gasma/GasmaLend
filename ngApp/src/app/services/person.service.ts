import { Injectable } from '@angular/core';
import { Person } from '../models/person.model';
import { RestService } from './rest.service';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private rest: RestService) { }

  getAllPerson()
  {
    this.rest.sendGetRequest('api/person');
  }

  savePerson(person: Person) : boolean
  {
    if (person.id == null)
      this.rest.sendPostRequest('api/person', person).subscribe(res => {
        return res.success
      });
    else
      this.rest.sendPutRequest('api/person', person).subscribe(res => {
        return res.success
      });

    return false;
  }
}
