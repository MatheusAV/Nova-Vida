using NovaVidaDomain.Models;
using NovaVidaInfra.Common;
using NovaVidaInfra.Interfaces;

namespace NovaVidaInfra.Repositories
{
    public class ProfessorRepository : BaseRepository, IProfessorRepository
    {

        public ProfessorRepository(DbContextApplication rep) : base(rep)
        {
        }

        public Professor InseriProf(Professor professor)
        {
            try
            {
                _rep.Add(professor);
                _rep.SaveChanges();

                return professor;
            }

            catch (Exception)
            {
                throw;
            }
        }


        public List<Professor> ListaProfs()
        {
            try
            {
                var professores = _rep.Professores.ToList();

                return professores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Professor BuscaProfId(int idProf)
        {
            try
            {
                var professor = _rep.Professores.FirstOrDefault(m => m.ProfessorId == idProf);

                if (professor == null)
                {
                    throw new Exception($"Professor com ID {idProf} não encontrado.");
                }

                return professor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteProf(int idProf)
        {
            try
            {
                var professor = _rep.Professores.FirstOrDefault(m => m.ProfessorId == idProf);

                if (professor != null)
                {
                    _rep.Remove(professor);
                    _rep.SaveChanges();
                    return $"Professor com ID {idProf} removido com sucesso!";
                }
                else
                {
                    throw new Exception($"Professor com ID {idProf} não encontrado.");
                }
            }
            catch (Exception)
            {
                return $"Erro ao remover professor com ID {idProf}.";
            }
        }

        public Professor AtualizaProfessor(Professor professorAtualizado)
        {
            try
            {
                var professor = _rep.Professores.Where(m => m.ProfessorId == professorAtualizado.ProfessorId).FirstOrDefault();
                if (professor != null)
                {
                    professor.Nome = professorAtualizado.Nome;
                    professor.DataContratacao = professorAtualizado.DataContratacao;
                    professor.Departamento = professorAtualizado.Departamento;
                    professor.Materia = professorAtualizado.Materia;

                    _rep.SaveChanges();

                    return professor;
                }
                else
                {
                    throw new Exception($"Professor com ID {professorAtualizado.ProfessorId} não encontrado.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task InseriProfessores(List<Professor> profs)
        {
            try
            {
                _rep.Set<Professor>().AddRange(profs);

                await _rep.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
