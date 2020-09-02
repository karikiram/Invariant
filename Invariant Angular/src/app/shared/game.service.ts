import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Game } from './game.model'; 
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  gameList: Game[];
  gameFormData: Game;

  private apiURL = "http://localhost:61373/api";

  constructor(private http: HttpClient) { }

  getGames(): Observable<Game[]>{
    return this.http.get<Game[]>(this.apiURL + '/Games/GetGames');
  }

  postGame(data): Observable<any> {
    return this.http.post(this.apiURL + '/Games/PostNewGame', data);
  }

  deleteGame(id): Observable<any> {
    return this.http.delete(this.apiURL + '/Games/DeleteGame/' + id);
  }
}
