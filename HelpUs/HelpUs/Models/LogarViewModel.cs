using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelpUs.Models
{
    public class LogarViewModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Falha { get; set; }
    }
}