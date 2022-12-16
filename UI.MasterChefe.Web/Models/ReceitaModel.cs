using System.ComponentModel.DataAnnotations;

namespace UI.MasterChefe.Web.Models
{
    public class ReceitaModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Por favor preencha o campo de título")]
        public string? titulo { get; set; }

        [Required(ErrorMessage = "Por favor preencha o campo de descrição")]
        public string? descricao { get; set; }

        [Required(ErrorMessage = "Por favor preencha o campo de modo de fazer")]
        public string? modoFazer { get; set; }

        public string? imagem { get; set; }
        public DateTime? dataCadastro { get; set; }
        public IEnumerable<IngredienteModel>? ingredientes { get; set; }
        public List<ReceitaModel>? receitas { get; set; }

        [Required(ErrorMessage = "Por favor selecione um arquivo")]
        public IFormFile arquivo { get; set; }
    }
}
