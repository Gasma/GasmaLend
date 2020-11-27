import { AfterViewInit, Component, ViewChild } from '@angular/core';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from 'src/app/services/user.service';
import { GameService } from 'src/app/services/game.service';
import { PersonComponent } from './person/person.component';
import { GameComponent } from './game/game.component';
import { Game } from 'src/app/models/game.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements AfterViewInit {

  displayedColumns: string[] = ['name', 'description', 'lend', 'action'];
  dataSource: MatTableDataSource<Game>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<any>;

  constructor(private service: UserService,
    private gameService: GameService,
    public dialog: MatDialog)
    {
    this.getAllGame();
  }

  onLogOut()
  {
    this.service.logout();
  }

  ngAfterViewInit()
  {

  }

  applyFilter(event: Event)
  {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  getAllGame()
  {
    this.gameService.getAllGame().subscribe(data => {
      if (data.success) {
        this.dataSource = new MatTableDataSource(data.data);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }
      else
      this.dataSource = new MatTableDataSource();
    });
  }

  openDialogLend(action, obj) {
    obj.action = action;
    const dialogRef = this.dialog.open(GameComponent, {
      width: '300px',
      height: (obj.action == 'Delete')? '250px': '450px',
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result == null)
        return;
      if(result.event == 'Add'){
        this.addRowData(result.data);
      }else if(result.event == 'Update'){
        this.updateRowData(result.data);
      }else if(result.event == 'Delete'){
        this.deleteRowData(result.data);
      }
    });
  }
  openDialogPerson(action,obj) {
    obj.action = action;
    const dialogRef = this.dialog.open(PersonComponent, {
      width: '250px',
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result == null)
        return;
      if(result.event == 'Add'){
        this.addRowData(result.data);
      }else if(result.event == 'Update'){
        this.updateRowData(result.data);
      }else if(result.event == 'Delete'){
        this.deleteRowData(result.data);
      }
    });
  }

  addRowData(row_obj)
  {
    this.gameService.saveGame(row_obj).subscribe(res => {
      if (res.success)
      {
        this.getAllGame();
        this.table.renderRows();
      }
    })
  }

  updateRowData(row_obj)
  {
    this.gameService.saveGame(row_obj).subscribe(res => {
      if (res.success)
      {
        this.getAllGame();
        this.table.renderRows();
      }
    })
  }

  deleteRowData(row_obj)
  {
    // this.dataSource = this.dataSource.filter((value,key)=>{
    //   return value.id != row_obj.id;
    // });
  }

}
