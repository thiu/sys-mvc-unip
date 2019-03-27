using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace SistemaMVC.Models
{
    public class TarefasModelo : List<Tarefas>
    {
        public TarefasModelo()
        {
            var c1 = new Conexao();
            c1.conexaodb.Open();

            string query = "SELECT * FROM tbl_tarefas";
            OleDbCommand cmd = new OleDbCommand(query, c1.conexaodb);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tarefa = new Tarefas(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3));
                    Add(tarefa);
                }
            }

            c1.conexaodb.Close();
        }
    }
}