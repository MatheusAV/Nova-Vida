using NovaVidaDomain.Models;
using NovaVidaInfra.Common;
using NovaVidaInfra.Interfaces;

namespace NovaVidaInfra.Repositories
{
    public class AlunoRepository : BaseRepository, IAlunoRepository
    {

        public AlunoRepository(DbContextApplication rep) : base(rep)
        {
        }

        public Aluno InseriAluno(Aluno aluno)
        {
            try
            {
                _rep.Add(aluno);
                _rep.SaveChanges();

                return aluno;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Aluno> ListaAlunos(int idProfessor)
        {
            try
            {
                var alunosDoProfessor = _rep.Alunos.Where(a => a.IdProfessor == idProfessor).ToList();
                return alunosDoProfessor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Aluno>> ListarTodosAlunos()
        {
            try
            {
                return  _rep.Alunos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar todos os alunos: " + ex.Message);
            }
        }

        public Aluno BuscaAlunoId(int idProf)
        {
            try
            {
                var aluno = _rep.Alunos.FirstOrDefault(m => m.AlunoId == idProf);

                if (aluno == null)
                {
                    throw new Exception($"Aluno com ID {idProf} não encontrado.");
                }

                return aluno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteAluno(int idAluno)
        {
            try
            {
                var aluno = _rep.Alunos.FirstOrDefault(m => m.AlunoId == idAluno);

                if (aluno != null)
                {
                    _rep.Remove(aluno);
                    _rep.SaveChanges();

                    return $"Aluno com ID {idAluno} removido com sucesso!";
                }
                else
                {
                    throw new Exception($"Aluno com ID {idAluno} não encontrado.");
                }
            }
            catch (Exception)
            {
                return $"Erro ao remover aluno com ID {idAluno}.";
            }
        }

        public Aluno AtualizaAluno(int idAluno, Aluno alunoAtualizado)
        {
            try
            {
                var aluno = _rep.Alunos.Where(m => m.AlunoId == idAluno).FirstOrDefault();
                if (aluno != null)
                {
                    aluno.Nome = alunoAtualizado.Nome;
                    aluno.ValorMensalidade = alunoAtualizado.ValorMensalidade;
                    aluno.DataVencimento = alunoAtualizado.DataVencimento;

                    _rep.SaveChanges();

                    return aluno;
                }
                else
                {
                    throw new Exception($"Aluno com ID {idAluno} não encontrado.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task InseriAlunos(List<Aluno> alunos)
        {
            try
            {
                _rep.Set<Aluno>().AddRange(alunos);

                await _rep.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
