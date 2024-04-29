using NovaVidaDomain.Models;

namespace NovaVidaServices.Interfaces
{
    public interface IProfessorService
    {
        Professor InseriProf(Professor professor);
        List<Professor> ListaProfs();
        Professor BuscaProfId(int idProf);
        string DeleteProf(int idProf);
        Professor AtualizaProf(Professor professorAtualizado);
        Task<List<Professor>> InseriProfessores(List<Professor> profs);
    }
}
