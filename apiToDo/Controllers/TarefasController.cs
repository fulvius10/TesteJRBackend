using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [AllowAnonymous]// coloquei isso pois estava dando erro no Swagger e vi pelo google que isso permitia o acesso do core.
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        [Authorize]
        [HttpPost("lstTarefas")]
        public ActionResult lstTarefas()  
        {
            try
            {
                Tarefas tarefas = new Tarefas();//nesses dois eu faço a instancia  
                var resposta = tarefas.lstTarefas();//e atribuição de tarefas do tipo Tarefas, em uma variavel "global" reposta.

                return Ok(resposta); //Ok faz a conversao neste caso de um status 200 com o Tarefas objeto (resposta). (Foi mais ou menos isso que eu consegui entender do diretorio da microsoft). --Ação síncrona--
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});//status code 400 dá retorna quando não existe.
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {
                Tarefas tarefas = new Tarefas();//Aqui, da mesma forma que o de cima, apenas com objetivo diferente. Toda vez que executamos esse metodo InserirTarefas, entramos numa parte que de 3 counts 
                tarefas.InserirTarefa(Request);// da listagem padrão, conseguimos adicionar 1, ficando no total de 4 countss. Porém, nesta forma estamos associando apenas sempre +1. Pois a lista vai ser renovada a cada execução.
                var resposta = tarefas.lstTarefas();//voltando a 3 e depois 4 counts quando passar aqui.
                return Ok(resposta);// conversão e atribuiçao para a lstTarefa.


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
                Tarefas tarefas = new Tarefas();//Aqui também, como o de cima criamos neste escopo e acessamos a partir disso a variável que acessa a listagem, porém quando acessamos aqui temos o count 2 no final.
                tarefas.DeletarTarefa(ID_TAREFA);//com o mesmo numero 3 depois de terminar de executar. a lista volta para 3.
                var resposta = tarefas.lstTarefas();


                return Ok(resposta);// conversão e atribuição para lstTarefa
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
