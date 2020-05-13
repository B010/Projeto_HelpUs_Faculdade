using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpUs.Models
{
    public class HomeViewModel
    {
        public int IdCaso { get; set; }
        public string TituloCaso { get; set; }

        public Casos CasoDetalhes { get; set; }

        public List<Casos> ListCasos { get; set; } = new List<Casos>();
        public List<Categorias> ListCategoria { get; set; } = new List<Categorias>();

    }
}