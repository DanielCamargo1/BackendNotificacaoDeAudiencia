namespace BackendNotificacaoDeAudiecia.Models
{
    public class AudienciaModels
    {
        public int Id { get; set; }
        public string? Nome { get; set; } 
        public int QuantidadeDePessoas { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
    }
}
