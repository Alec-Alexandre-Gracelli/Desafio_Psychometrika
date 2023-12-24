namespace Desafio_Psychometrika.Models
{
    public class ProvaSimulado
    {
        public Guid ProvaSimuladoId { get; set; }
        public Guid UsuarioId { get; set; }
        public string ProvaNome { get; set; }
        public virtual List<Questoes> Questoes { get; set; }
    }
}
