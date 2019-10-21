namespace ProjectReceitas.Domain.Domain
{
    public class ReceitaIngrediente
    {
        public int Id { get; set; }

        public int ReceitaId { get; set; }
        public virtual Receita Receita { get; set; }

        public string Descricao { get; set; }

    }
}