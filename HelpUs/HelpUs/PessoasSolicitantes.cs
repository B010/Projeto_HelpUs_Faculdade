//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpUs
{
    using System;
    using System.Collections.Generic;
    
    public partial class PessoasSolicitantes
    {
        public int IdPessoa { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdOutraEmpresa { get; set; }
        public string NomePessoa { get; set; }
        public string Setor { get; set; }
        public string CPF { get; set; }
    
        public virtual Empresas Empresas { get; set; }
        public virtual OutrasEmpresas OutrasEmpresas { get; set; }
    }
}
