using Desafio_Psychometrika.Models.Enum;

namespace Desafio_Psychometrika.Models
{
    public class AlternativaQuestoes
    {
        public Guid AlternativaQuestoesId { get; set; }
        public Guid QuestoesId { get; set; }
        public Alternativas Alternativas { get; set; }
        public bool Correta { get; set; }
    }
}
