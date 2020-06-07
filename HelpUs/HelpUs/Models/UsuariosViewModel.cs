using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelpUs.Models
{
    public class UsuariosViewModel
    {
        public int IdLogin { get; set; }

        public IEnumerable<SelectListItem> CategoriasSelect { get; set; } = new List<SelectListItem>();

        public List<Login> ListUsuarios { get; set; } = new List<Login>();
    }
}