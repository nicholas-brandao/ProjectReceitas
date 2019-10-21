using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectReceitas.Domain.Domain
{
    public class ReceitaModoPreparo
    {
        public int Id { get; set; }

        public int ReceitaId { get; set; }
        public virtual Receita Receita { get; set; }

        [Display(Name = "Nome")]
        public string Descricao { get; set; }
    }
}
