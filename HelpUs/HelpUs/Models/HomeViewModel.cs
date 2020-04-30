using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpUs.Models
{
    public class HomeViewModel
    {
        public List<Casos> ListCasos { get; set; } = new List<Casos>();
        public List<Categoria> ListCategoria { get; set; } = new List<Categoria>();

        //public class Casos
        //{
        //    public int IdCaso { get; set; }
        //    public int? IdCategoria { get; set; }
        //    public int? IdEmpresa { get; set; }
        //    public int? IdOutraEmpresa { get; set; }
        //    public int? QuantidadeTotal { get; set; }
        //    public int? Quantidade { get; set; }
        //    public decimal? ValorTotal { get; set; }
        //    public decimal? Valor { get; set; }
        //    public string TituloCaso { get; set; }
        //    public string DescricaoCaso { get; set; }
        //    public bool Ativo { get; set; }
        //    public Nullable<bool> Avaliacao { get; set; }
        //}

        public class Categoria
        {
            public int IdCategoria { get; set; }
            public string NomeCategoria { get; set; }
            public int TipoCategoria { get; set; }
            public bool ativo { get; set; }
        }
    }
}