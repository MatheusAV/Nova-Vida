using Microsoft.AspNetCore.Mvc;
using NovaVidaDomain.Models;
using NovaVidaServices.Interfaces;

namespace NovaVida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : AppBaseController
    {
        public AlunosController(IProfessorService professorService, IAlunoService alunoService) : base(professorService, alunoService)
        {
        }

        [HttpPost("InseriAluno")]
        public IActionResult InseriAluno(Aluno aluno)
        {
            try
            {
                _alunoService.InseriAluno(aluno);
                return Ok(aluno);

            }
            catch (Exception err)
            {

                return StatusCode(500, new
                {
                    Message = err
                });
            }
        }

        [HttpPost("InseriListaAlunos")]
        public async Task<IActionResult> InseriListaAlunos([FromBody] List<Aluno> alunos)
        {

            try
            {
                var response = await _alunoService.InseriAlunos(alunos);
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

        [HttpGet("ListaAlunos")]
        public IActionResult ListaAlunos(int idProf)
        {
            try
            {
                List<Aluno> alunosList = _alunoService.ListaAlunos(idProf);
                return Ok(alunosList);

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
        public IActionResult BuscaAlunoId(int idAluno)
        {
            try
            {
                Aluno aluno = _alunoService.BuscaAlunoId(idAluno);
                return Ok(aluno);

            }
            catch (Exception err)
            {

                return StatusCode(500, new
                {
                    Message = err.Message
                });
            }
        }

        [HttpPut("AtualizaAluno")]
        public IActionResult AtualizaAluno(int idAluno, Aluno aluno)
        {
            try
            {
                Aluno alunoAtualizado = _alunoService.AtualizaAluno(idAluno, aluno);
                return Ok(alunoAtualizado);

            }
            catch (Exception err)
            {

                return StatusCode(500, new
                {
                    Message = err.Message
                });
            }
        }

        [HttpDelete("DeletaAluno")]
        public IActionResult DeletaAluno(int idAluno)
        {
            try
            {
                string message = _alunoService.DeleteAluno(idAluno);
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