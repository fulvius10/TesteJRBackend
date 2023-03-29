using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        List<TarefaDTO> listaTarefa = new List<TarefaDTO>();//atribui de maneira global a lista de tarefas do tipo List<TarefaDTO>, de onde se pega os parametros. E a cada vez, por não ter cache e nem banco ele executa corretamente
        //um metodo dessas funções. lstTarefas, inserir e deletar. E tambem para acessar de maneira global a mesma variavel em dois metodos.
        public Tarefas()//construtor para adicionar itens a lista de tarefas.
        {
            listaTarefa.Add(new TarefaDTO
            {
                ID_TAREFA = 1,
                DS_TAREFA = "Fazer Compras"
            });

            listaTarefa.Add(new TarefaDTO
            {
                ID_TAREFA = 2,
                DS_TAREFA = "Fazer Atividad Faculdade"
            });

            listaTarefa.Add(new TarefaDTO
            {
                ID_TAREFA = 3,
                DS_TAREFA = "Subir Projeto de Teste no GitHub"
            });
           
        }
        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                return listaTarefa;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void InserirTarefa(TarefaDTO Request)
        {
            try
            {
                List<TarefaDTO> lstResponse = lstTarefas();
                lstResponse.Add(Request);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                List<TarefaDTO> lstResponse = lstTarefas();
                var Tarefa = lstResponse.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                TarefaDTO Tarefa2 = lstResponse.Where(x => x.ID_TAREFA == Tarefa.ID_TAREFA).FirstOrDefault();
                lstResponse.Remove(Tarefa2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
