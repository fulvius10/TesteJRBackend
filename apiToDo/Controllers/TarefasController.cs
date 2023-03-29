using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        [Authorize]
        [HttpPost("lstTarefas")]
        public ActionResult lstTarefas()
        {
            try
            {
                Tarefas tarefas = new Tarefas();
                var resposta = tarefas.lstTarefas();

                return Ok(resposta);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {
                Tarefas tarefas = new Tarefas();
                tarefas.InserirTarefa(Request);
                var resposta = tarefas.lstTarefas();
                return Ok(resposta);


            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpGet("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                Tarefas tarefas = new Tarefas();
                tarefas.DeletarTarefa(ID_TAREFA);
                var resposta = tarefas.lstTarefas();


                return Ok(resposta);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
