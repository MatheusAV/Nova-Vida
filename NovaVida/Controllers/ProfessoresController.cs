using Microsoft.AspNetCore.Mvc;
using NovaVidaDomain.Models;
using NovaVidaServices.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaVida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController : AppBaseController
    {
        public ProfessoresController(IProfessorService professorService, IAlunoService alunoService) : base(professorService, alunoService)
        {
        }


        [HttpPost("InseriProfLista")]        
        public async Task<IActionResult> InseriListaProfs([FromBody] List<Professor> Profs)
        {

            try
            {
                var response = await _profService.InseriProfessores(Profs);
                if (response.Count != 0)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception err)
            {

                return StatusCode(500, new
                {
                    Message = err.Message
                });
            }
        }


        [HttpPost("InseriProf")]
        public IActionResult InseriProf(Professor prof)
        {
            try
            {
                _profService.InseriProf(prof);
                return Ok(prof);

            }
            catch (Exception err)
            {

                return StatusCode(500, new
                {
                    Message = err.Message
                });
            }
        }

        [HttpGet("ListaProfs")]
        public IActionResult ListaProfs()
        {
            try
            {
                List<Professor> profList = _profService.ListaProfs();
                return Ok(profList);

            }
            catch (Exception err)
            {

                return StatusCode(500, new
                {
                    Message = err.Message
                });
            }
        }

        [HttpGet("BuscaID")]
        public IActionResult BuscaProfId(int idProf)
        {
            try
            {
                Professor prof = _profService.BuscaProfId(idProf);
                return Ok(prof);

            }
            catch (Exception err)
            {

                return StatusCode(500, new
                {
                    Message = err.Message
                });
            }
        }

        [HttpPut("AtualizaProf")]
        public IActionResult AtualizaProf(Professor professor)
        {
            try
            {
                Professor prof = _profService.AtualizaProf(professor);
                return Ok(prof);

            }
            catch (Exception err)
            {

                return StatusCode(500, new
                {
                    Message = err.Message
                });
            }
        }

        [HttpDelete("DeletaProf")]
        public IActionResult DeletaProf(int idProf)
        {
            try
            {
                string message = _profService.DeleteProf(idProf);
                return Ok(message);

            }
            catch (Exception err)
            {

                return StatusCode(500, new
                {
                    Message = err.Message
                });
            }
        }
    }

}