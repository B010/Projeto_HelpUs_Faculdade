using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelpUs.Models
{
    public class CasosViewModel
    {
        public int IdCaso { get; set; }
        public int? QuantidadeTotal { get; set; }
        public int? Quantidade { get; set; }
        public decimal? ValorTotal { get; set; }
        public decimal? Valor { get; set; }
        public string TituloCaso { get; set; }
        public string DescricaoCaso { get; set; }
        public int? IdCategoria { get; set; }

        public IEnumerable<SelectListItem> CategoriasSelect { get; set; } = new List<SelectListItem>();
    }
}