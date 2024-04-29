import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Professor } from 'src/app/Models/Professor';

@Component({
  selector: 'app-professor-form',
  templateUrl: './professor-form.component.html',
  styleUrls: ['./professor-form.component.css']
})
export class ProfessorFormComponent implements OnInit{

  @Output() onSubmit = new EventEmitter<Professor>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input() dadosProfessor: Professor | null = null;

  professorForm!: FormGroup;

  constructor(){}

  ngOnInit(): void {


    this.professorForm = new FormGroup({
      professorId: new FormControl(this.dadosProfessor ? this.dadosProfessor.professorId : 0),
      nome: new FormControl(this.dadosProfessor ? this.dadosProfessor.nome : '', [Validators.required]),
      dataContratacao: new FormControl(new Date()),
      departamento: new FormControl(this.dadosProfessor ? this.dadosProfessor.departamento : '', [Validators.required]),
      materia: new FormControl(this.dadosProfessor ? this.dadosProfessor.materia :'', [Validators.required]),
    })

  }

  submit(){

  this.onSubmit.emit(this.professorForm.value);

  }

}
