namespace ProjectReceitas.Domain.Domain
{
    public class ReceitaIngrediente
    {
        public int Id { get; set; }
        public Receita Receita { get; set; }
        public string Descricao { get; set; }

    }
}