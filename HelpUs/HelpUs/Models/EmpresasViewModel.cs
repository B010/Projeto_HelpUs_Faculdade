using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelpUs.Models
{
    public class EmpresasViewModel
    {
        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public string EmailEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string CEP { get; set; }
        public string TelefoneEmpresas { get; set; }
        public string UfEmpresa { get; set; }
        public string CidadeEmpresa { get; set; }
        public IEnumerable<SelectListItem> UfEmpresaSelect { get; set; } = new List<SelectListItem>();
        public List<Empresas> ListEmpresas { get; set; } = new List<Empresas>();
    }
}