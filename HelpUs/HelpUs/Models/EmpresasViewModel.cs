using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelpUs.Models
{
    public class EmpresasViewModel
    {
        public int IdEmpresa { get; set; }

        public IEnumerable<SelectListItem> EmpresasSelect { get; set; } = new List<SelectListItem>();

        public List<Empresas> ListEmpresas { get; set; } = new List<Empresas>();
    }
}