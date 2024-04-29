import { HelperService } from 'src/app/services/helper.service';
import { Professor } from './../../Models/Professor';
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ExcluirComponent } from 'src/app/componentes/excluir/excluir.component';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent  implements OnInit {

  profs : Professor[] = [];
  professorGeral : Professor[] = [];  
  pageSize: number = 5;   
  dataSource = new MatTableDataSource<Professor>();
  colunas = ['Id professor', 'Nome', 'Data contratação', 'Departamento', 'Materia', 'Exluir', 'Acoes'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
   
  constructor( private helperService: HelperService, public dialog: MatDialog){}

    ngOnInit(): void {

      this.helperService.GetProfessores().subscribe(data => {
        const dados = data.map((item) => {
          item.dataContratacao = new Date(item.dataContratacao!).toLocaleDateString('pt-BR');
          return item;
        });        
        this.profs = dados;
        this.professorGeral = dados;    
        this.dataSource.data = this.profs;
      });      
    }

    search(event : Event){
      const target = event.target as HTMLInputElement;
      const value = target.value.toLowerCase();

      this.profs = this.professorGeral.filter(professor =>{
        return professor.nome.toLowerCase().includes(value) || professor.professorId.toString().includes(value);
      });
    } 
    

    ngAfterViewInit(): void {
      this.dataSource.paginator = this.paginator;
    }

    openDialog(id: number)
    {
      this.dialog.open(ExcluirComponent, {
        width: '350px',
        height: '350px',
        data: {
          id: id
        }
      });
    }
}

