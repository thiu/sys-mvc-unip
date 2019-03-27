using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SistemaMVC.Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        [DisplayName("Tarefa")]
        [Required]

        public string NomeTarefa { get; set; }
        [DisplayName("Descrição")]
        [Required]
        public string DescricaoTarefa { get; set; }
        [DisplayName("Data")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataTarefa { get; set; }
        
        public Tarefas(int id, string nome_tarefa, string descricao_tarefa, DateTime data_tarefa)
        {
            Id = id;
            NomeTarefa = nome_tarefa;
            DescricaoTarefa = descricao_tarefa;
            DataTarefa = data_tarefa;
        }

        public Tarefas()
        {

        }


    }
}