namespace UI.MasterChefe.Web.Models
{
    public class ReceitaModel
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string modoFazer { get; set; }
        public string imagem { get; set; }
        public IEnumerable<IngredienteModel> ingredientes { get; set; }
    }
}
