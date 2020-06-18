using HelpUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Util.Dictionary;

namespace HelpUs.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index(string usuario = "", bool falha = false)
        {
            var viewModel = new LogarViewModel()
            {
                Falha = falha,
                Usuario = usuario
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Logar(LogarViewModel model)
        {
            DbHelpUsEntities db = new DbHelpUsEntities();
            var user = db.Login.Where(x => x.Usuario == model.Usuario && x.Senha == model.Senha).FirstOrDefault();
            if(user !=  null)
            {
                Session["logado"] = user;
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index",new{ falha = true, usuario = model.Usuario });
        }
    }
}