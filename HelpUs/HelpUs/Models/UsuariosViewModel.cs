using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelpUs.Models
{
    public class UsuariosViewModel
    {
        public int IdLogin { get; set; }
        public int? IdEmpresa { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public IEnumerable<SelectListItem> EmpresasSelect { get; set; } = new List<SelectListItem>();

        public List<Login> ListUsuarios { get; set; } = new List<Login>();
    }
}