using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<IEnumerable<TblMatricula>> GetAllMatricula(int usuarioId);
        Task<TblMatricula> GetMatriculaById(int id);
        Task<TblMatricula> PostMatricula(TblMatricula matricula);
        Task<TblMatricula> DeleteMatriculaById(int id);
    }
}
