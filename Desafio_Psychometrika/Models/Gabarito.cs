using Desafio_Psychometrika.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Desafio_Psychometrika.Models
{
    public class Gabarito
    {
        public Guid GabaritoId { get; set; }
        public Guid ProvaSimuladoId { get; set; }
        public Guid QuestoesId { get; set;}
        public Resposta RespostaCorreta { get; set;}
    }
}
