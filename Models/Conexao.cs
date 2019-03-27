using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaMVC.Models
{
    public class Conexao
    {
        public OleDbConnection conexaodb;

        public Conexao()
        {
            string conexaoAccess = ConfigurationManager.ConnectionStrings["conexaoAccess"].ToString();
            conexaodb = new OleDbConnection(conexaoAccess);

        }

    }
}