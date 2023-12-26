using System.ComponentModel.DataAnnotations;

namespace Desafio_Psychometrika.Models
{
    public class Gabarito
    {
        public Guid GabaritoId { get; set; }
        public Guid ProvaSimuladoId { get; set; }
        public Guid QuestoesId { get; set;}

        [StringLength(1)]
        public string RespostaCorreta { get; set;}
    }
}
