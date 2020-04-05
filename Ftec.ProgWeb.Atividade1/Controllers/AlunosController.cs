using Ftec.ProgWeb.Atividade1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ftec.ProgWeb.Atividade1.Controllers
{
    
    public class AlunosController : Controller
    {
        //Lista usada para listagem
        public static List<Aluno> Alunos = new List<Aluno>();
        //Lista usada apenas para listagem da pesquisa
        public static List<Aluno> Pesquisa = new List<Aluno>();

        public ActionResult Index()
        {
            if (Pesquisa.Count() == 0)
            {
                return View(Alunos);
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
        public ActionResult Gravar(Aluno aluno)
        {    
            if(Alunos.Count() == 0)
            {
                aluno.Codigo = 1;
            }
            else
            {
                aluno.Codigo = Alunos.Select(x => x.Codigo).Max() + 1;
            }
            Alunos.Add(aluno);
            Pesquisa.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult Procurar(string busca)
        {
            Pesquisa = Alunos.Where(x => x.Codigo.ToString() == busca || x.Nome.Contains(busca) || x.Turma.Contains(busca) || x.Idade.ToString() == busca).ToList();
            return RedirectToAction("Index");
        }
        public ActionResult Excluir(int codigo)
        {
            var alunoExcluido = Alunos.Find(x => x.Codigo == codigo);
            Alunos.Remove(alunoExcluido);
            Pesquisa.Clear();
            return RedirectToAction("Index");
        }
    }
}