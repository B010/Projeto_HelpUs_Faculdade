using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpUs.Models
{
    public class HomeViewModel
    {
        public List<Casos> ListCasos { get; set; } = new List<Casos>();
        public List<Categorias> ListCategoria { get; set; } = new List<Categorias>();

    }
}