//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fiap.Projeto.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pergunta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pergunta()
        {
            this.Resposta = new HashSet<Resposta>();
        }
    
        public int Id { get; set; }
        public int AlunoRm { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Tag { get; set; }
        public System.DateTime Data { get; set; }
        public Nullable<int> RespostaEscolhida { get; set; }
    
        public virtual Aluno Aluno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resposta> Resposta { get; set; }
    }
}
