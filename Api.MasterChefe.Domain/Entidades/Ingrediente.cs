namespace Api.MasterChefe.Domain.Entidades
{
    public class Ingrediente : EntityBase
    {
        public string? Nome { get; set; }
        public string? descricao { get; set; } 
        public decimal? peso { get; set; }
        public int? quantidade { get; set; }
        public int receitaId { get; set; }
    }
}
