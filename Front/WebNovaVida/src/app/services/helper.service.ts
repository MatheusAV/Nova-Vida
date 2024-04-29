import { Professor } from './../Models/Professor';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Aluno } from '../Models/Aluno';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class HelperService {

private apiUrl = `${environment.ApiUrl}/Professores`

private apiUrlAluno = `${environment.ApiUrl}/Alunos`



  constructor( private http: HttpClient) { }


GetProfessores(): Observable<Professor[]>{

  return this.http.get<Professor[]>(this.apiUrl+"/ListaProfs");
}

GetProfId(professorId: number): Observable<Professor>{

  return this.http.get<Professor>(this.apiUrl+"/BuscaID?idProf="+professorId);
}

GetAlunoId(idAluno: number): Observable<Aluno>{

  return this.http.get<Aluno>(this.apiUrlAluno+"/BuscaID?idAluno="+idAluno);
}

InsertProfessores(professor: Professor): Observable<Professor[]>{

  return this.http.post<Professor[]>(this.apiUrl+"/InseriProf", professor);
}

GetAlunos(): Observable<Aluno[]>{

  return this.http.get<Aluno[]>(this.apiUrlAluno);
}

AtualizaProf(pro: Professor): Observable<Professor[]>{
  {
    return this.http.put<Professor[]>(this.apiUrl+"/AtualizaProf", pro);
  }
}


ListaAlunos(idPro: Number): Observable<Aluno[]>{
  {
    return this.http.get<Aluno[]>(this.apiUrlAluno+"/ListaAlunos?idProf="+idPro);
  }
}


ExluirAluno(idAluno: number): Observable<Aluno[]>{
  return this.http.delete<Aluno[]>(this.apiUrlAluno+"/DeletaAluno?idAluno="+idAluno);
}

ExluirProf(idPro: number): Observable<Professor[]>{
  return this.http.delete<Professor[]>(this.apiUrl+"/DeletaProf?idProf="+idPro);
}


}



