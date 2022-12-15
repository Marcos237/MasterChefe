namespace UI.MasterChefe.Web.Models
{
    public class IngredienteModel
    {
        public int id { get; set; }
        public string? Nome { get; set; }
        public string? descricao { get; set; }
        public decimal? peso { get; set; }
        public int? quantidade { get; set; }
        public int receitaId { get; set; }
    }
}
