namespace Api.MasterChefe.Domain.Entidades
{
    public class EntityBase
    {
        public int id { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataAtualizacao { get; set; }
        public bool ativo { get; set; }
    }
}
