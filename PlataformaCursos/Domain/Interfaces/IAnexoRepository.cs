using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Domain.Interfaces
{
    public interface IAnexoRepository
    {
        Task<IEnumerable<TblAnexo>> GetAllAnexo(int cursoId);
        Task<TblAnexo> GetAnexoById(int id);
        Task<TblAnexo> PutAnexo(TblAnexo anexo);
        Task<TblAnexo> PostAnexo(TblAnexo anexo);
        Task<TblAnexo> DeleteAnexoById(int id);
    }
}
