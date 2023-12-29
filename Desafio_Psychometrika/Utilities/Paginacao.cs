namespace Desafio_Psychometrika.Utilities
{
    public class Paginacao<T>
    {
        private int totalItens;
        private int itensPorPagina;

        public int PaginaAtual { get; private set; }
        public int TotalPaginas { get; private set; }
        public List<T> Itens { get; private set; }

        public Paginacao(List<T> itens, int totalItens, int paginaAtual, int itensPorPagina)
        {
            this.totalItens = totalItens;
            PaginaAtual = paginaAtual;
            this.itensPorPagina = itensPorPagina;

            TotalPaginas = (int)Math.Ceiling((double)totalItens / itensPorPagina);

            Itens = itens.Skip((paginaAtual - 1) * itensPorPagina).Take(itensPorPagina).ToList();
        }

        public bool TemPaginaAnterior
        {
            get { return (PaginaAtual > 1); }
        }

        public bool TemProximaPagina
        {
            get { return (PaginaAtual < TotalPaginas); }
        }

        public static Paginacao<T> Criar(List<T> fonte, int paginaAtual, int itensPorPagina)
        {
            var totalItens = fonte.Count;

            return new Paginacao<T>(fonte, totalItens, paginaAtual, itensPorPagina);
        }
    }
}
