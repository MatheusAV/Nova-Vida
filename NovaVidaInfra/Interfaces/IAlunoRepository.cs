using NovaVidaDomain.Models;

namespace NovaVidaInfra.Interfaces
{
    public interface IAlunoRepository
    {
        Aluno InseriAluno(Aluno aluno);
        List<Aluno> ListaAlunos(int idProfessor);
        Aluno BuscaAlunoId(int idProf);
        string DeleteAluno(int idAluno);
        Aluno AtualizaAluno(int idAluno, Aluno alunoAtualizado);
        Task InseriAlunos(List<Aluno> alunos);
        Task<List<Aluno>> ListarTodosAlunos();
    }
}
