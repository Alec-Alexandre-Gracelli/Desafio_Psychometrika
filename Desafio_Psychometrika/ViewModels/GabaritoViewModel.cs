using Desafio_Psychometrika.Models;

namespace Desafio_Psychometrika.ViewModels
{
    public class GabaritoViewModel
    {
        public Usuario Usuarios { get; set; }
        public List<Questoes> Questoes { get; set; }
        public List<AlternativaQuestoes> AlternativaQuestoes { get; set; }
    }
}
