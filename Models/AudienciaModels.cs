using System.ComponentModel.DataAnnotations;

namespace BackendNotificacaoDeAudiecia.Models
{
    public class AudienciaModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Precisa ser informado um nome")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Precisa ser informado a quantidade de pessos")]
        public int QuantidadeDePessoas { get; set; }
        [Required(ErrorMessage = "Precisa ser digitado a cidade")]
        public string? Cidade { get; set; }
        [Required(ErrorMessage = "Precisa ser digitado o Estado")]
        public string? Uf { get; set; }
    }
}
