using Microsoft.AspNetCore.Mvc;
using NovaVidaServices.Interfaces;

namespace NovaVida.Controllers
{
    public class AppBaseController : ControllerBase
    {
        protected readonly IProfessorService _profService;
        protected readonly IAlunoService _alunoService;
        public AppBaseController(IProfessorService professorService, IAlunoService alunoService)
        {
            _profService = professorService;
            _alunoService = alunoService;
        }
    }
}
