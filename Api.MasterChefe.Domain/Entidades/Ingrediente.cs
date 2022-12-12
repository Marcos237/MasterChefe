namespace Api.MasterChefe.Domain.Entidades
{
    public class Ingrediente : EntityBase
    {
        public string? descricao { get; set; }
        public string? peso { get; set; }
        public int? quantidade { get; set; }
    }
}
