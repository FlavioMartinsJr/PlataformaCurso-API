using System.ComponentModel.DataAnnotations;

namespace PlataformaCursos.API.Models
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue)]
        public int NumeroPagina { get; set; }
        [Range(1, 50, ErrorMessage = "O máximo de itens por página é 50.")]
        public int ItemsPagina { get; set; }
    }
}
