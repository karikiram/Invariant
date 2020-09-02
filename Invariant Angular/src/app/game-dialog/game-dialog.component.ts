import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Game } from '../shared/game.model';
import { GameListComponent } from '../game-list/game-list.component';
import { FormGroup, FormBuilder, NgForm } from '@angular/forms';
import { GameService } from '../shared/game.service';

@Component({
  selector: 'app-game-dialog',
  templateUrl: './game-dialog.component.html',
  styles: [
  ]
})
export class GameDialogComponent implements OnInit {

  form: FormGroup;

  constructor(private formbuilder: FormBuilder,
    private dialogRef: MatDialogRef<GameListComponent>,
    private gameService: GameService) {

}

  ngOnInit(){
    this.form = this.formbuilder.group({
      GameId: 0,
      GameName: '',
      GameDescription: ''
    })
  }


  submit(form: any) {
    this.dialogRef.close();
    this.gameService.postGame(form.value).subscribe(
          res => {
            this.gameService.getGames();
            location.reload();
          });
        }
    
close() {
    this.dialogRef.close();
}
}
