using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Models
{
    public class ReceitaModoPreparo
    {
        public int Id { get; set; }
        public Receita Receita { get; set; }
        public string Descricao { get; set; }
    }
}
