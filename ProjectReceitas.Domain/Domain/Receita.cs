using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Domain.Domain
{
    public class Receita
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int HoraPreparo { get; set; }
        public int MinutoPreparo { get; set; }
        public int Rendimento { get; set; }

        public ICollection<ReceitaIngrediente> Ingredientes { get; set; }
        public ICollection<ReceitaModoPreparo> ModoPreparos { get; set; }
    }
}
