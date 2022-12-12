namespace Api.MasterChefe.Domain.Entidades
{
    public class Ingrediente : EntityBase
    {
        public string? Nome { get; set; }
        public decimal? peso { get; set; }
        public int? quantidade { get; set; }
    }
}
