using Ftec.ProgWeb.Atividade1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ftec.ProgWeb.Atividade1.Controllers
{
    public class FuncionariosController : Controller
    {
        //Lista usada para listagem
        public static List<Funcionario> Funcionarios = new List<Funcionario>();
        //Lista usada apenas para listagem da pesquisa
        public static List<Funcionario> Pesquisa = new List<Funcionario>();

        public ActionResult Index()
        {
            if (Pesquisa.Count() == 0)
            {
                return View(Funcionarios);
            }
            else
            {
                return View(Pesquisa);
            }

        }
        //tela de cadastro--poderia ser usada para alteração tb
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult Gravar(Funcionario Funcionario)
        {
            if (Funcionarios.Count() == 0)
            {
                Funcionario.Codigo = 1;
            }
            else
            {
                Funcionario.Codigo = Funcionarios.Select(x => x.Codigo).Max() + 1;
            }
            Funcionarios.Add(Funcionario);
            Pesquisa.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult Procurar(string busca)
        {
            Pesquisa = Funcionarios.Where(x => x.Codigo.ToString() == busca || x.Nome.Contains(busca) || x.Cargo.Contains(busca) || x.Idade.ToString() == busca).ToList();
            return RedirectToAction("Index");
        }
        public ActionResult Excluir(int codigo)
        {
            var FuncionarioExcluido = Funcionarios.Find(x => x.Codigo == codigo);
            Funcionarios.Remove(FuncionarioExcluido);
            Pesquisa.Clear();
            return RedirectToAction("Index");
        }
    }
}