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
            if (Session["logado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            DbHelpUsEntities db = new DbHelpUsEntities();

            List<Casos> casos;

            var empresa = Convert.ToInt32(Session["empresa"]);

            if (Convert.ToBoolean(Session["admin"]))
            {
                casos = db.Casos.ToList();
            }
            else
            {
                casos = db.Casos.Where(x=> x.IdEmpresa == empresa).ToList();
            }
            

            HomeViewModel model = new HomeViewModel()
            {
                ListCasos = casos
            };

            return View(model);
        }

        public ActionResult New(CasosViewModel model)
        {
            if (Session["logado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            DbHelpUsEntities db = new DbHelpUsEntities();
            List<Categorias> categorias = db.Categorias.ToList();
            IDictionary<int, string> combocategorias = new Dictionary<int, string>();

            foreach (var cat in categorias)
            {
                combocategorias.Add(cat.IdCategoria, cat.NomeCategoria);
            }

            CasosViewModel viewModel = new CasosViewModel()
            {
                DescricaoCaso = model.DescricaoCaso,
                TituloCaso = model.TituloCaso,
                Quantidade = model.Quantidade,
                QuantidadeTotal = model.QuantidadeTotal,
                Valor = model.Valor,
                ValorTotal = model.ValorTotal,
                IdCategoria = model.IdCategoria,
                CategoriasSelect = combocategorias.AsSelectListItem()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CasosViewModel model, string valor)
        {
            if (Session["logado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            model.Valor = Convert.ToDecimal(valor, new System.Globalization.CultureInfo("pt-BR"));
            if (string.IsNullOrEmpty(model.TituloCaso))
            {
                return RedirectToAction(nameof(New), new { model });
            }
            if (model.Quantidade == null && model.Valor == null)
            {
                return RedirectToAction(nameof(New), new { model });
            }
            if (string.IsNullOrEmpty(model.DescricaoCaso))
            {
                return RedirectToAction(nameof(New), new { model });
            }

            DbHelpUsEntities db = new DbHelpUsEntities();

            db.Casos.Add(new Casos { DescricaoCaso = model.DescricaoCaso, Quantidade = model.Quantidade, Valor = model.Valor, IdCategoria = model.IdCategoria, TituloCaso = model.TituloCaso, Ativo = true, IdEmpresa = Convert.ToInt32(Session["empresa"]) , Avaliacao = false, QuantidadeTotal = 0, ValorTotal = 0 });
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id, string error)
        {
            if (Session["logado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

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

        [HttpPost]
        public ActionResult Update(CasosViewModel model, string valor)
        {
            if (Session["logado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            model.Valor = Convert.ToDecimal(valor, new System.Globalization.CultureInfo("pt-BR"));
            if (string.IsNullOrEmpty(model.TituloCaso))
            {                
                return RedirectToAction(nameof(Edit), new { id = model.IdCaso });
            }
            if (model.Quantidade == null && model.Valor == null)
            {
                return RedirectToAction(nameof(Edit), new { id = model.IdCaso });
            }
            if (string.IsNullOrEmpty(model.DescricaoCaso))
            {
                return RedirectToAction(nameof(Edit), new { id = model.IdCaso });
            }

            DbHelpUsEntities db = new DbHelpUsEntities();
            var caso = db.Casos.First(a => a.IdCaso == model.IdCaso);

            caso.IdCategoria = model.IdCategoria;
            caso.Quantidade = model.Quantidade;
            caso.Valor = model.Valor;
            caso.TituloCaso = model.TituloCaso;
            caso.DescricaoCaso = model.DescricaoCaso;

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            if (Session["logado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            DbHelpUsEntities db = new DbHelpUsEntities();
            db.Casos.Remove(db.Casos.Single(a => a.IdCaso == id));
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}