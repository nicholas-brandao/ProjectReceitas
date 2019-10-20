using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectReceitas.Models
{
    public class Receita
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [Display(Name ="Hora")]
        public int HoraPreparo { get; set; }

        [Display(Name = "Minutos")]
        public int MinutoPreparo { get; set; }

        public int Rendimento { get; set; }

        public ICollection<ReceitaIngrediente> Ingredientes { get; set; }
        public ICollection<ReceitaModoPreparo> ModosPreparo { get; set; }
    }
}
