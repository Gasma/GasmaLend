import { Person } from './person.model';

export class Game {
  name: string;
  description: string;
  personId: string;
  id: string;
  active: boolean;
  inactivateAt:Date;
  creationAt:Date;
  person: Person
}
