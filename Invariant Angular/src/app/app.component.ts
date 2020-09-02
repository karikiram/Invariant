import { Component, OnInit } from '@angular/core';
import { Game } from './shared/game.model';
import { GameService } from './shared/game.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: []
})
export class AppComponent implements OnInit {
  title = 'Invariant';

  gameList: Game[];
  gameCount: number = 0;

  constructor(public gameService: GameService) { }

  ngOnInit(){
    this.gameService.getGames()
    .subscribe(x=> {
      this.gameList = x;
      this.gameCount = this.gameList.length;
    })
  }
}
