import { Component, OnInit } from '@angular/core';
import { Game } from '../shared/game.model';
import { GameService } from '../shared/game.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { GameDialogComponent } from '../game-dialog/game-dialog.component';

@Component({
  selector: 'app-game-list',
  templateUrl: './game-list.component.html',
  styles: [
  ]
})
export class GameListComponent implements OnInit {

  gameList: Game[];

  constructor(public gameService: GameService, private dialog: MatDialog) { }

  ngOnInit(){
    this.gameService.getGames()
    .subscribe(x=> {
      this.gameList = x;
    })
  }

  openDialog() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    this.dialog.open(GameDialogComponent, dialogConfig);

}

deleteGame(GameId) {
  if (confirm('Are you sure to delete this game?')) {
    this.gameService.deleteGame(GameId)
      .subscribe(res => {
        this.gameService.getGames()
    .subscribe(x=> {
      this.gameList = x;
    })
      });
    }
  }

  moveUp(id) {
    let index = this.gameList.findIndex(x => x.GameId == id);
    if (index > 0) {
      let el = this.gameList[index];
      this.gameList[index] = this.gameList[index - 1];
      this.gameList[index - 1] = el;
    }
  }
  
  moveDown(id) {
    let index = this.gameList.findIndex(x => x.GameId == id);
    if (index !== -1 && index < this.gameList.length - 1) {
      let el = this.gameList[index];
      this.gameList[index] = this.gameList[index + 1];
      this.gameList[index + 1] = el;
    }
  }

}
