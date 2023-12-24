namespace Desafio_Psychometrika.Models
{
    public class Questoes
    {
        public Guid QuestoesId { get; set; }
        public Guid ProvaSimuladoId { get; set;}
        public int Questao { get; set; }
        public virtual List<AlternativaQuestoes> AlternativaQuestoes { get; set; }
    }
}
