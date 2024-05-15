using PlataformaCursos.Application.DTOs.Anexo;
using PlataformaCursos.Application.DTOs.Capitulo;

namespace PlataformaCursos.Application.Interfaces
{
    public interface ICapituloService
    {
        Task<IEnumerable<CapituloGet>> BuscaCapitulo(int cursoId);
        Task<CapituloGet> BuscaCapituloPorId(int id);
        Task<CapituloPost> AdicionaCapitulo(CapituloPost capitulo);
        Task<CapituloPut> AtualizaCapitulo(CapituloPut capitulo);
        Task<CapituloPut> DeletaCapituloPorId(int id);
    }
}
