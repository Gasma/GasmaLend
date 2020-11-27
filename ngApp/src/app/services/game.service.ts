import { Injectable } from '@angular/core';
import { Game } from '../models/game.model';
import { RestService } from './rest.service';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(private rest: RestService) { }

  getAllGame()
  {
    return this.rest.sendGetRequest('api/game');
  }

  saveGame(game: Game)
  {
    if (game.id == null)
      return this.rest.sendPostRequest('api/game', game);
    else
      return this.rest.sendPutRequest('api/game', game);

  }
}
