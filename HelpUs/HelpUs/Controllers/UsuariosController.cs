using HelpUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Util.Dictionary;

namespace HelpUs.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Index()
        {
            DbHelpUsEntities db = new DbHelpUsEntities();

            List<Login> logins = db.Login.ToList();

            UsuariosViewModel model = new UsuariosViewModel()
            {
                ListUsuarios = logins
            };

            return View(model);
        }

        public ActionResult New(UsuariosViewModel model)
        {
            DbHelpUsEntities db = new DbHelpUsEntities();
            List<Empresas> empresas = db.Empresas.ToList();
            IDictionary<int, string> comboEmpresas = new Dictionary<int, string>();

            foreach (var emp in empresas)
            {
                comboEmpresas.Add(emp.IdEmpresa, emp.NomeEmpresa);
            }

            UsuariosViewModel viewModel = new UsuariosViewModel()
            {
                Usuario = model.Usuario,
                Senha = model.Senha,
                IdEmpresa = model.IdEmpresa,
                TipoUsuario = model.TipoUsuario,
                EmpresasSelect = comboEmpresas.AsSelectListItem()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(UsuariosViewModel model)
        {
            if (model.IdEmpresa == 0)
            {
                return RedirectToAction(nameof(New), new { model });
            }

            DbHelpUsEntities db = new DbHelpUsEntities();

            db.Login.Add(new Login { IdEmpresa = model.IdEmpresa, Usuario = model.Usuario, Senha = model.Senha, TipoUsuario = model.TipoUsuario });
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            DbHelpUsEntities db = new DbHelpUsEntities();
            Login login = db.Login.Where(x => x.IdLogin == id).FirstOrDefault();

            List<Empresas> empresas = db.Empresas.ToList();

            IDictionary<int, string> comboEmpresas = new Dictionary<int, string>();

            foreach (var cat in empresas)
            {
                comboEmpresas.Add(cat.IdEmpresa, cat.NomeEmpresa);
            }

            UsuariosViewModel model = new UsuariosViewModel()
            {
                IdLogin = id,
                Usuario = login.Usuario,
                Senha = login.Senha,
                IdEmpresa = login.IdEmpresa,
                TipoUsuario = login.TipoUsuario,
                EmpresasSelect = comboEmpresas.AsSelectListItem()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UsuariosViewModel model)
        {
            if (model.IdEmpresa == 0)
            {
                return RedirectToAction(nameof(New), new { model });
            }

            DbHelpUsEntities db = new DbHelpUsEntities();
            var login = db.Login.First(a => a.IdLogin == model.IdLogin);

            login.Usuario = model.Usuario;
            login.Senha = model.Senha;
            login.IdEmpresa = model.IdEmpresa;
            login.TipoUsuario = model.TipoUsuario;

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            DbHelpUsEntities db = new DbHelpUsEntities();
            db.Login.Remove(db.Login.Single(a => a.IdLogin == id));
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}