using SistemaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.CSSatrasado = "btn btn-success";
            ViewBag.CSSentregar = "btn btn-success";
            ViewBag.QntAtrasadas = atrasadas();
            ViewBag.QntEntregar = entregar();

            if (ViewBag.QntAtrasadas > 0)
            {
                ViewBag.CSSatrasado = "btn btn-danger";
            }
            if (ViewBag.QntEntregar > 0)
            {
                ViewBag.CSSentregar = "btn btn-warning";
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Informações sobre o sistema";

            return View();
        }
        public int atrasadas()
        {
            var c1 = new Conexao();
            c1.conexaodb.Open();

            string query = "SELECT COUNT(*) FROM tbl_tarefas WHERE data_tarefa < @Hoje";
            OleDbCommand cmd = new OleDbCommand(query, c1.conexaodb);

            var pmtHoje = cmd.CreateParameter();
            pmtHoje.ParameterName = "@Hoje";
            pmtHoje.DbType = DbType.DateTime;
            pmtHoje.Value = DateTime.Today;
            cmd.Parameters.Add(pmtHoje);

            Int32 qntAtrasadas = Convert.ToInt32(cmd.ExecuteScalar());
            c1.conexaodb.Close();

            return (qntAtrasadas);
        }
        public int entregar()
        {
            var c1 = new Conexao();
            c1.conexaodb.Open();

            string query = "SELECT COUNT(*) FROM tbl_tarefas WHERE data_tarefa = @Hoje";
            OleDbCommand cmd = new OleDbCommand(query, c1.conexaodb);

            var pmtHoje = cmd.CreateParameter();
            pmtHoje.ParameterName = "@Hoje";
            pmtHoje.DbType = DbType.DateTime;
            pmtHoje.Value = DateTime.Today;
            cmd.Parameters.Add(pmtHoje);

            Int32 qntEntregar = Convert.ToInt32(cmd.ExecuteScalar());
            c1.conexaodb.Close();

            return (qntEntregar);
         }
    }
}