using NovaVidaDomain.Models;

namespace NovaVidaInfra.Interfaces
{
    public interface IProfessorRepository
    {
        Professor InseriProf(Professor professor);
        List<Professor> ListaProfs();
        Professor BuscaProfId(int idProf);
        string DeleteProf(int idProf);
        Professor AtualizaProfessor(Professor profAtualizado);
        Task InseriProfessores(List<Professor> profs);
    }
}
