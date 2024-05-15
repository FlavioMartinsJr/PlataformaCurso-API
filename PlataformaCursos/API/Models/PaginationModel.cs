
using PlataformaCursos.Application.DTOs.Curso;

namespace PlataformaCursos.API.Models
{
    public class PaginationModel
    {
        public int PaginaAtual { get; set; }
        public int ItemsPagina { get; set; }
        public int TotalItems { get; set; }
        public int TotalPagina { get; set; }

        public PaginationModel(int paginaAtual, int itemsPagina, int totalItems, int totalPagina)
        {
            PaginaAtual = paginaAtual;
            ItemsPagina = itemsPagina;
            TotalItems = totalItems;
            TotalPagina = totalPagina;
        }
    }
}
