import { Router } from '@angular/router';
import { HelperService } from 'src/app/services/helper.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog'
import { firstValueFrom, Observable  } from 'rxjs';

@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html',
  styleUrls: ['./excluir.component.css']
})
export class ExcluirComponent implements OnInit {
  inputData: any;
  result!: any;

  constructor(
    private helperService: HelperService,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private ref: MatDialogRef<ExcluirComponent>) { }

  ngOnInit(): void {
    this.inputData = this.data;
    this.getProfData();
    this.getAlunoData();
  }

  getProfData(): void {
    this.helperService.GetProfId(this.inputData.id).subscribe((data) => {
      this.result = data;
    });
  }

  getAlunoData(): void {
    this.helperService.GetAlunoId(this.inputData.id).subscribe((data) => {
      this.result = data;
    });
  }

  Excluir(item: any) {
    let operacao: Observable<any> | undefined;

    if (item.professorId) {
      operacao = this.helperService.ExluirProf(item.professorId);
    } else if (item.alunoId) {
      operacao = this.helperService.ExluirAluno(item.alunoId);
    }

    if (operacao) {
      firstValueFrom(operacao).then(
        (response) => {
          console.log('Resposta da exclusão:', response);
          if (response && response.hasOwnProperty('error')) {
            console.error('Erro durante a exclusão:', response['error']);
          } else {
            console.log('Exclusão bem-sucedida');
          }
        },
        (error) => {
          console.error('Erro durante a exclusão:', error);
        }
      ).finally(() => {
        this.ref.close();
        window.location.reload();
      });
    } else {
      console.error('Operação indefinida. Verifique os IDs fornecidos.');
      this.ref.close();
      window.location.reload();
    }
}

Cancelar(){
  this.ref.close();
}
}

