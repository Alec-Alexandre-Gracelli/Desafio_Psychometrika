using System.ComponentModel.DataAnnotations;

namespace Desafio_Psychometrika.Models
{
    public class ProvaSimulado
    {
        public Guid ProvaSimuladoId { get; set; }

        [StringLength(100)]
        public string ProvaNome { get; set; }
        public virtual List<Questoes> Questoes { get; set; }
        public virtual List<Usuario> Usuarios { get; set; }
    }
}
