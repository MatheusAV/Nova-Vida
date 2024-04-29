using NovaVidaInfra.Interfaces;

namespace NovaVidaServices.Services
{
    public class BaseService
    {
        protected readonly IAlunoRepository _repAluno;
        protected readonly IProfessorRepository _repProf;
       
        public BaseService(IAlunoRepository alunoRepository, IProfessorRepository professorRepository)
        {
            _repAluno = alunoRepository;
            _repProf = professorRepository;
        }
    }
}
