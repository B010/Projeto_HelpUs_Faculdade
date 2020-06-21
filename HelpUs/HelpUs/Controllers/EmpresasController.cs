using HelpUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Util.Dictionary;

namespace HelpUs.Controllers
{
    public class EmpresasController : Controller
    {
        public ActionResult Index()
        {
            DbHelpUsEntities db = new DbHelpUsEntities();

            List<Empresas> empresas = db.Empresas.Where(x => x.ativo == true).ToList();

            EmpresasViewModel model = new EmpresasViewModel()
            {
                ListEmpresas = empresas
            };

            return View(model);
        }

        public ActionResult New(EmpresasViewModel model)
        {
            #region Estados
            var estados = new string[,]
            {
                { "AC"},
                { "AL"},
                { "AP"},
                { "AM"},
                { "BA"},
                { "CE"},
                { "DF"},
                { "ES"},
                { "GO"},
                { "MA" },
                { "MT"},
                { "MS" },
                { "MG"},
                { "PA"},
                { "PB"},
                { "PR"},
                { "PE"},
                { "PI"},
                { "RJ"},
                { "RN"},
                { "RS" },
                { "RO"},
                { "RR"},
                { "SC" },
                { "SP"},
                { "SE"},
                { "TO" }
            };
            #endregion

            IDictionary<string, string> comboEstados = new Dictionary<string, string>();

            foreach (var est in estados)
            {
                comboEstados.Add(est, est);
            }

            EmpresasViewModel viewModel = new EmpresasViewModel()
            {
                IdEmpresa = model.IdEmpresa,
                CEP = model.CEP,
                CidadeEmpresa = model.CidadeEmpresa,
                Cnpj = model.Cnpj,
                EmailEmpresa = model.EmailEmpresa,
                NomeEmpresa = model.NomeEmpresa,
                TelefoneEmpresas = model.TelefoneEmpresas,
                UfEmpresa = model.UfEmpresa,
                UfEmpresaSelect = comboEstados.AsSelectListItem()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(EmpresasViewModel model)
        {
            DbHelpUsEntities db = new DbHelpUsEntities();

            db.Empresas.Add(new Empresas { UfEmpresa = model.UfEmpresa,TelefoneEmpresa = 1, TelefoneEmpresas = model.TelefoneEmpresas, NomeEmpresa = model.NomeEmpresa, EmailEmpresa = model.EmailEmpresa, Cnpj = model.Cnpj, CEP = model.CEP, CidadeEmpresa = model.CidadeEmpresa, ativo = true, DataDisativacao = null });
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id, string error)
        {
            #region Estados
            var estados = new string[,]
            {
                { "AC"},
                { "AL"},
                { "AP"},
                { "AM"},
                { "BA"},
                { "CE"},
                { "DF"},
                { "ES"},
                { "GO"},
                { "MA" },
                { "MT"},
                { "MS" },
                { "MG"},
                { "PA"},
                { "PB"},
                { "PR"},
                { "PE"},
                { "PI"},
                { "RJ"},
                { "RN"},
                { "RS" },
                { "RO"},
                { "RR"},
                { "SC" },
                { "SP"},
                { "SE"},
                { "TO" }
            };
            #endregion

            DbHelpUsEntities db = new DbHelpUsEntities();
            Empresas empresas = db.Empresas.Where(x => x.IdEmpresa == id).FirstOrDefault();

            
            IDictionary<string, string> comboEstados = new Dictionary<string, string>();
            foreach (var est in estados)
            {
                comboEstados.Add(est, est);
            }
            EmpresasViewModel model = new EmpresasViewModel()
            {
                IdEmpresa = empresas.IdEmpresa,
                CEP = empresas.CEP,
                CidadeEmpresa = empresas.CidadeEmpresa,
                Cnpj = empresas.Cnpj,
                EmailEmpresa = empresas.EmailEmpresa,
                NomeEmpresa = empresas.NomeEmpresa,
                TelefoneEmpresas = empresas.TelefoneEmpresas,
                UfEmpresa = empresas.UfEmpresa,
                UfEmpresaSelect = comboEstados.AsSelectListItem()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(EmpresasViewModel model)
        {
            DbHelpUsEntities db = new DbHelpUsEntities();
            var empresa = db.Empresas.First(a => a.IdEmpresa == model.IdEmpresa);

            empresa.CEP = model.CEP;
            empresa.CidadeEmpresa = model.CidadeEmpresa;
            empresa.Cnpj = model.Cnpj;
            empresa.EmailEmpresa = model.EmailEmpresa;
            empresa.NomeEmpresa = model.NomeEmpresa;
            empresa.TelefoneEmpresas = model.TelefoneEmpresas;
            empresa.UfEmpresa = model.UfEmpresa;

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            DbHelpUsEntities db = new DbHelpUsEntities();
            var empresa = db.Empresas.First(a => a.IdEmpresa == id);

            empresa.ativo = false;
            empresa.DataDisativacao = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}