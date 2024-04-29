import { ActivatedRoute, Router } from '@angular/router';
import { HelperService } from 'src/app/services/helper.service';
import { Professor } from './../../Models/Professor';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit{

  btnAcao = "Editar!"
  btnTitulo = "Editar professor"
  prof! : Professor;

  constructor(private HelperService: HelperService, private route: ActivatedRoute, private router: Router){}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('professorId'));
    this.HelperService.GetProfId(id).subscribe((data) =>{
      this.prof = data;

    });
  }

  editarProfessor(professorAtualizado: Professor){

    this.HelperService.AtualizaProf(professorAtualizado).subscribe((data) =>{
      this.router.navigate(['/']);
    });

  }


}
