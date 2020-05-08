using HelpUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Util.Dictionary;

namespace HelpUs.Controllers
{
    public class CasosController : Controller
    {
        public ActionResult Index()
        {
            DbHelpUsEntities db = new DbHelpUsEntities();

            List<Casos> casos = db.Casos.ToList();

            HomeViewModel model = new HomeViewModel()
            {
                ListCasos = casos
            };

            return View(model);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            DbHelpUsEntities db = new DbHelpUsEntities();
            Casos casos = db.Casos.Where(x => x.IdCaso == id).FirstOrDefault();

            List<Categorias> categorias = db.Categorias.ToList();

            IDictionary<int, string> combocategorias = new Dictionary<int, string>();

            foreach (var cat in categorias)
            {
                combocategorias.Add(cat.IdCategoria, cat.NomeCategoria);
            }

            CasosViewModel model = new CasosViewModel()
            {
                IdCaso = id,
                DescricaoCaso = casos.DescricaoCaso,
                TituloCaso = casos.TituloCaso,
                Quantidade = casos.Quantidade,
                QuantidadeTotal = casos.QuantidadeTotal,
                Valor = casos.Valor,
                ValorTotal = casos.ValorTotal,
                IdCategoria = casos.IdCategoria,
                CategoriasSelect = combocategorias.AsSelectListItem()
            };

            return View(model);
        }

        public ActionResult Update(CasosViewModel model)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            DbHelpUsEntities db = new DbHelpUsEntities();
            db.Casos.Remove(db.Casos.Single(a => a.IdCaso == id));
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}