namespace Api.MasterChefe.Domain.Entidades
{
    public class Receita : EntityBase
    {
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string modoFazer { get; set; }
        public string imagem { get; set; }
        public List<Ingrediente> ingredientes { get; set; }


    }
}
