using Desafio_Psychometrika.Models.Enum;
using System.Reflection.Metadata.Ecma335;

namespace Desafio_Psychometrika.Models
{
    public class UsuarioProva
    {
        public Guid UsuarioProvaId { get; set; }
        public Guid ProvaSimuladoId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid QuestoesId { get; set; }
        public Resposta? Resposta { get; set; }
        public bool Respondido { get; set; }
    }
}
