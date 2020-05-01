﻿using HelpUs.Models;
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

            List<Casos> casos = db.Casos.Where(x => x.Ativo == true && x.Avaliacao == true).ToList();

            HomeViewModel model = new HomeViewModel()
            {
                ListCasos = casos,
                ListCategoria = categoria
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}