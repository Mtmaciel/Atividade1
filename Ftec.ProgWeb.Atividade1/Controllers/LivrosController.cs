using Ftec.ProgWeb.Atividade1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ftec.ProgWeb.Atividade1.Controllers
{
    public class LivrosController : Controller
    {

        //Lista usada para listagem
        public static List<Livro> Livros = new List<Livro>();
        //Lista usada apenas para listagem da pesquisa
        public static List<Livro> Pesquisa = new List<Livro>();

        public ActionResult Index()
        {
            if (Pesquisa.Count() == 0)
            {
                return View(Livros);
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
        public ActionResult Gravar(Livro Livro)
        {
            if (Livros.Count() == 0)
            {
                Livro.Codigo = 1;
            }
            else
            {
                Livro.Codigo = Livros.Select(x => x.Codigo).Max() + 1;
            }
            Livros.Add(Livro);
            Pesquisa.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult Procurar(string busca)
        {
            Pesquisa = Livros.Where(x => x.Codigo.ToString() == busca || x.Titulo.Contains(busca) || x.Genero.Contains(busca) || x.Paginas.ToString() == busca||x.Ano.ToString() ==busca).ToList();
            return RedirectToAction("Index");
        }
        public ActionResult Excluir(int codigo)
        {
            var LivroExcluido = Livros.Find(x => x.Codigo == codigo);
            Livros.Remove(LivroExcluido);
            Pesquisa.Clear();
            return RedirectToAction("Index");
        }
    }
}