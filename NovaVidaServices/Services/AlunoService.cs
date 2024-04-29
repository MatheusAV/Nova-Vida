using Microsoft.Extensions.Logging;
using NovaVidaDomain.Models;
using NovaVidaInfra.Interfaces;
using NovaVidaServices.Interfaces;

namespace NovaVidaServices.Services
{
    public class AlunoService : BaseService, IAlunoService
    {
        private readonly ILogger<AlunoService> _logger;
        public AlunoService(IAlunoRepository alunoRepository, IProfessorRepository professorRepository, ILogger<AlunoService> logger) : base(alunoRepository, professorRepository)
        {
            _logger = logger;
        }

        public Aluno InseriAluno(Aluno aluno)
        {
            try
            {
                var professor = _repProf.BuscaProfId(aluno.IdProfessor);
                if (professor == null)
                {
                    throw new InvalidOperationException($"Impossível inserir o aluno porque o professor com ID {aluno.IdProfessor} não foi encontrado.");
                }

                var alunoInserido = _repAluno.InseriAluno(aluno);
                _logger.LogInformation("Aluno inserido com sucesso!");
                return alunoInserido;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao inserir aluno. Detalhes: {ex.Message}");
                throw;
            }
        }

        public List<Aluno> ListaAlunos(int idProf)
        {
            List<Aluno> listaAlunos = new List<Aluno>();
            try
            {
                var alunos = _repAluno.ListaAlunos(idProf);
                if (alunos != null && alunos.Count > 0)
                {
                    foreach (var aluno in alunos)
                    {
                        listaAlunos.Add(aluno);
                    }
                    _logger.LogInformation("Sucesso: Alunos listados com sucesso.");
                }
                else
                {
                    _logger.LogInformation("Informação: Nenhum aluno encontrado.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar alunos. Detalhes: {ex.Message}");
                throw;
            }

            return listaAlunos;
        }

        public Aluno BuscaAlunoId(int idAluno)
        {
            try
            {
                var Aluno = _repAluno.BuscaAlunoId(idAluno);
                if (Aluno != null)
                {
                    _logger.LogInformation($"Sucesso: Aluno com ID {idAluno} encontrado com sucesso.");
                }
                else
                {
                    throw new Exception($"Erro: Aluno com ID {idAluno} não encontrado.");
                }
                return Aluno;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter o Aluno com ID {idAluno}. Detalhes: {ex.Message}");
                throw;
            }
        }

        public string DeleteAluno(int idAluno)
        {
            try
            {
                var mensagem = _repAluno.DeleteAluno(idAluno);
                _logger.LogInformation(mensagem);
                return mensagem;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao remover aluno com ID {idAluno}. Detalhes: {ex.Message}");
                throw;
            }
        }

        public Aluno AtualizaAluno(int idAluno, Aluno AlunoAtualizado)
        {
            try
            {
                var prof = _repAluno.AtualizaAluno(idAluno, AlunoAtualizado);
                _logger.LogInformation($"Sucesso: Aluno com ID {AlunoAtualizado.Nome} atualizado com sucesso!");
                return prof;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar Aluno. Detalhes: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Aluno>> InseriAlunos(List<Aluno> alunos)
        {
            var alunosInseridos = new List<Aluno>();
            try
            {
                var nomesExistentes = new HashSet<string>((await _repAluno.ListarTodosAlunos()).Select(a => a.Nome));

                foreach (var aluno in alunos)
                {
                    if (!nomesExistentes.Contains(aluno.Nome))
                    {
                        alunosInseridos.Add(aluno);
                    }
                }

                if (alunosInseridos.Any())
                {
                    await _repAluno.InseriAlunos(alunosInseridos);
                    return alunosInseridos;
                }
                else
                {
                    return new List<Aluno>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir alunos: {ex.Message}");
            }
        }

    }
}
