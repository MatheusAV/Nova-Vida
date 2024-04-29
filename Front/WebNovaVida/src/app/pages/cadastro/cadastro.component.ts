import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Professor } from 'src/app/Models/Professor';
import { HelperService } from 'src/app/services/helper.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent {

  btnAcao = "Cadastrar!"
  btnTitulo = "Cadastrar professor"

  constructor (private helperService: HelperService, private router: Router){

  }

  createProfessor(professor: Professor){

    this.helperService.InsertProfessores(professor).subscribe((data )=> {
      this.router.navigate(['/'])
    });
  }

}
