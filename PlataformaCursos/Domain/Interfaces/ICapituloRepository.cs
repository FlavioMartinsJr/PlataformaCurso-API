using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Domain.Interfaces
{
    public interface ICapituloRepository
    {
        Task<IEnumerable<TblCapitulo>> GetAllCapitulo(int cursoId);
        Task<TblCapitulo> GetCapituloById(int id);
        Task<TblCapitulo> PutCapitulo(TblCapitulo capitulo);
        Task<TblCapitulo> PostCapitulo(TblCapitulo capitulo);
        Task<TblCapitulo> DeleteCapituloById(int id);
    }
}
