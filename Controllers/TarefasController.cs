using SistemaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace SistemaMVC.Controllers
{
    public class TarefasController : Controller
    {
        
        // GET: Tarefas
        public ActionResult Index()
        {
            var tm = new TarefasModelo();
            return View(tm);
        }

        public ActionResult Atrasadas()
        {
            var tm = new TarefasModelo();
            return View(tm.Where(t => t.DataTarefa < DateTime.Today));
        }

        public ActionResult Entregar()
        {
            var tm = new TarefasModelo();
            return View(tm.Where(t => t.DataTarefa == DateTime.Today));
        }

        // Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarefas task)
        {
            var c1 = new Conexao();
            c1.conexaodb.Open();

            string query = "INSERT INTO tbl_tarefas (nome_tarefa, descricao_tarefa, data_tarefa) VALUES (@Nome, @Descricao, @Data)";
            OleDbCommand cmd = new OleDbCommand(query, c1.conexaodb);

            var pmtNome = cmd.CreateParameter();
            pmtNome.ParameterName = "@Nome";
            pmtNome.DbType = DbType.String;
            pmtNome.Value = task.NomeTarefa;
            cmd.Parameters.Add(pmtNome);

            var pmtDescricao = cmd.CreateParameter();
            pmtDescricao.ParameterName = "@Descricao";
            pmtDescricao.DbType = DbType.String;
            pmtDescricao.Value = task.DescricaoTarefa;
            cmd.Parameters.Add(pmtDescricao);

            var pmtData = cmd.CreateParameter();
            pmtData.ParameterName = "@Data";
            pmtData.DbType = DbType.DateTime;
            pmtData.Value = task.DataTarefa;
            cmd.Parameters.Add(pmtData);

            cmd.ExecuteNonQuery();
            c1.conexaodb.Close();

            return RedirectToAction("Index");
        }

        // Edit 
        public ActionResult Edit(int id)
        {
            var tm = new TarefasModelo();
            return View(tm.Where(t => t.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tarefas task)
        {
            var c1 = new Conexao();
            c1.conexaodb.Open();

            string query = "UPDATE tbl_tarefas SET nome_tarefa = ?, descricao_tarefa = ?, data_tarefa = ? WHERE id = ?";
            OleDbCommand cmd = new OleDbCommand(query, c1.conexaodb);
            
            var pmtNome = cmd.CreateParameter();
            pmtNome.ParameterName = "@Nome";
            pmtNome.DbType = DbType.String;
            pmtNome.Value = task.NomeTarefa;
            cmd.Parameters.Add(pmtNome);

            var pmtDescricao = cmd.CreateParameter();
            pmtDescricao.ParameterName = "@Descricao";
            pmtDescricao.DbType = DbType.String;
            pmtDescricao.Value = task.DescricaoTarefa;
            cmd.Parameters.Add(pmtDescricao);

            var pmtData = cmd.CreateParameter();
            pmtData.ParameterName = "@Data";
            pmtData.DbType = DbType.DateTime;
            pmtData.Value = task.DataTarefa;
            cmd.Parameters.Add(pmtData);

            var pmtId = cmd.CreateParameter();
            pmtId.ParameterName = "@Id";
            pmtId.DbType = DbType.Int32;
            pmtId.Value = task.Id;
            cmd.Parameters.Add(pmtId);
            
            cmd.ExecuteNonQuery();
            c1.conexaodb.Close();

            return RedirectToAction("Index");
        }

        // Edit 
        public ActionResult Delete(int id)
        {
            var tm = new TarefasModelo();
            return View(tm.Where(t => t.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Tarefas task)
        {
            var c1 = new Conexao();
            c1.conexaodb.Open();

            string query = "DELETE FROM tbl_tarefas WHERE id = ?";
            OleDbCommand cmd = new OleDbCommand(query, c1.conexaodb);
            
            var pmtId = cmd.CreateParameter();
            pmtId.ParameterName = "@Id";
            pmtId.DbType = DbType.Int32;
            pmtId.Value = task.Id;
            cmd.Parameters.Add(pmtId);

            cmd.ExecuteNonQuery();
            c1.conexaodb.Close();

            return RedirectToAction("Index");

        }
    }
}