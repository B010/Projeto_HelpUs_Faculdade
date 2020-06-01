using HelpUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpUs.Controllers
{
    public class HomeController : Controller
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Details(int idCaso)
        {
            DbHelpUsEntities db = new DbHelpUsEntities();

            var caso = db.Casos.First(a => a.IdCaso == idCaso);

            var viewModel = new HomeViewModel()
            {
                CasoDetalhes = caso,
                
            };
            if (caso.ValorTotal != null)
                viewModel.ValorTotal = caso.ValorTotal;
            else
                viewModel.ValorTotal = 0;
            if (caso.Valor != null)
                viewModel.Valor = caso.Valor;
            else
                viewModel.Valor = 0;
            return View(viewModel);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}