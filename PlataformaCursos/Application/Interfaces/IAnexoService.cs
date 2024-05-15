using PlataformaCursos.Application.DTOs.Anexo;

namespace PlataformaCursos.Application.Interfaces
{
    public interface IAnexoService
    {
        Task<IEnumerable<AnexoGet>> BuscaAnexo(int cursoId);
        Task<AnexoGet> BuscaAnexoById(int id);
        Task<AnexoPost> AdicionaAnexo(AnexoPost anexo);
        Task<AnexoPut> AtualizaAnexo(AnexoPut anexo);
        Task<AnexoPut> DeletaAnexoPorId(int id);
    }
}
