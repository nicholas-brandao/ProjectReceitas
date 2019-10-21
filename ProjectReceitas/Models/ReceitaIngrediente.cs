﻿using System.ComponentModel.DataAnnotations;

namespace ProjectReceitas.Models
{
    public class ReceitaIngrediente
    {
        public int Id { get; set; }

        public int ReceitaId { get; set; }
        public virtual Receita Receita { get; set; }

        [Display(Name = "Nome")]
        public string Descricao { get; set; }

    }
}