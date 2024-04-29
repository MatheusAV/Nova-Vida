using Microsoft.Extensions.Logging;
using NovaVidaDomain.Models;
using NovaVidaInfra.Interfaces;
using NovaVidaServices.Interfaces;

namespace NovaVidaServices.Services
{
    public class ProfessorService : BaseService, IProfessorService
    {
        private readonly ILogger<ProfessorService> _logger;
        public ProfessorService(IAlunoRepository alunoRepository, IProfessorRepository professorRepository, ILogger<ProfessorService> logger) : base(alunoRepository, professorRepository)
        {
            _logger = logger;
        }

        public Professor InseriProf(Professor professor)
        {
            try
            {
                var profInserido = _repProf.InseriProf(professor);
                _logger.LogInformation("Professor inserido com sucesso!");
                return profInserido;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao inserir professor. Detalhes: {ex.Message}");
                throw;
            }
        }

        public List<Professor> ListaProfs()
        {
            try
            {
                var professores = _repProf.ListaProfs();
                List <Professor> profs = new List<Professor>();
                if (professores.Count != 0)
                {
                    foreach (var prof in professores)
                    {
                        prof.DataContratacao.ToString();
                        profs.Add(prof);
                    }
                    _logger.LogInformation("Sucesso: Professores listados com sucesso.");
                }
                else
                {
                    throw new Exception($"Erro:Nunhum professor encontrado.");
                }
                
                return profs;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar professores. Detalhes: {ex.Message}");
                throw;
            }
        }

        public Professor BuscaProfId(int idProf)
        {
            try
            {
                var professor = _repProf.BuscaProfId(idProf);
                if (professor != null)
                {
                    _logger.LogInformation($"Sucesso: Professor com ID {idProf} encontrado com sucesso.");
                }
                else
                {
                    throw new Exception($"Erro: Professor com ID {idProf} não encontrado.");
                }
                return professor;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter o Professor com ID {idProf}. Detalhes: {ex.Message}");
                throw;
            }
        }

        public string DeleteProf(int idProf)
        {
            try
            {
                var mensagem = _repProf.DeleteProf(idProf);
                _logger.LogInformation(mensagem);
                return mensagem;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao remover Professor com ID {idProf}. Detalhes: {ex.Message}");
                throw;
            }
        }

        public Professor AtualizaProf(Professor professorAtualizado)
        {
            try
            {
               var prof = _repProf.AtualizaProfessor(professorAtualizado);
                _logger.LogInformation($"Sucesso: Professor com ID {professorAtualizado.Nome} atualizado com sucesso!");
                return prof;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar professor. Detalhes: {ex.Message}");
                throw;
            } 
        }


        public async Task<List<Professor>> InseriProfessores(List<Professor> profs)
        {
            var professoresInseridos = new List<Professor>();
            try
            {                
                var todosProfessores =  _repProf.ListaProfs();

                foreach (var professor in profs)
                {                    
                    var professorExistente = todosProfessores.FirstOrDefault(p => p.Nome == professor.Nome);
                                      
                    if (professorExistente == null)
                    {
                        professoresInseridos.Add(professor);
                    }
                }

                if (professoresInseridos.Any())
                {
                    await _repProf.InseriProfessores(professoresInseridos);                    
                    return professoresInseridos;
                }
                else
                {
                    return new List<Professor>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir professores: {ex.Message}");
            }
        }      

    }
}
