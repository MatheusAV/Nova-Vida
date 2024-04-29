using NovaVidaDomain.Models;

namespace NovaVidaServices.Interfaces
{
    public interface IAlunoService
    {
        Aluno InseriAluno(Aluno aluno);
        List<Aluno> ListaAlunos(int idProf);
        Aluno BuscaAlunoId(int idAluno);
        string DeleteAluno(int idAluno);
        Aluno AtualizaAluno(int idAluno, Aluno AlunoAtualizado);
        Task<List<Aluno>> InseriAlunos(List<Aluno> alunos);

    }
}
