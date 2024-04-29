import { ActivatedRoute, Router } from '@angular/router';
import { Aluno } from 'src/app/Models/Aluno';
import { HelperService } from 'src/app/services/helper.service';
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ExcluirComponent } from 'src/app/componentes/excluir/excluir.component';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.css']
})
export class AlunoComponent implements OnInit{

  alunos : Aluno[] = []; 
  pageSize: number = 5; 
  dataSource = new MatTableDataSource<Aluno>();
  colunas = ['Id aluno', 'Nome', 'Valor mensalidade',  'Data vencimento', 'Id professor', 'Exluir']  
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private helperService: HelperService, private route: ActivatedRoute, private router: Router,
    public dialog: MatDialog){

  }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('professorId'));

    this.helperService.ListaAlunos(id).subscribe((data) =>{
      const dados = data

      dados.map((item) => {
        item.dataVencimento = new Date( item.dataVencimento!).toLocaleDateString('pt-BR');        
      })      
      this.alunos = data
      this.dataSource.data = this.alunos;
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
