using PlataformaCursos.Application.DTOs.Categoria;

namespace PlataformaCursos.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaGet>> BuscaCategoria();
        Task<CategoriaGet> BuscaCategoriaPorNome(string nome);
        Task<CategoriaGet> BuscaCategoriaPorId(int id);
        Task<CategoriaPost> AdicionaCategoria(CategoriaPost categoria);
        Task<CategoriaPut> AtualizaCategoria(CategoriaPut categoria);
        Task<CategoriaPut> DeletaCategoriaPorId(int id);
    }
}
