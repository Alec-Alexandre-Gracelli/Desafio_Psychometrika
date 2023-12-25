using Desafio_Psychometrika.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Desafio_Psychometrika.Models
{
    public class ProvaSimulado
    {
        public Guid ProvaSimuladoId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid QuestoesId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [StringLength(100)]
        public string ProvaNome { get; set; }
        public Resposta? Resposta { get; set; }
        public bool Respondido { get; set; }
    }
}
