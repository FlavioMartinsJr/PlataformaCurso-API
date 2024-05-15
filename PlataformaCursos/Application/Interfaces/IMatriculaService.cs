using PlataformaCursos.Application.DTOs.Capitulo;
using PlataformaCursos.Application.DTOs.Matricula;

namespace PlataformaCursos.Application.Interfaces
{
    public interface IMatriculaService
    {
        Task<IEnumerable<MatriculaGet>> BuscaMatricula(int usuarioId);
        Task<MatriculaGet> BuscaMatriculaPorId(int id);
        Task<MatriculaPost> AdicionaMatricula(MatriculaPost matriculaPost);
        Task<MatriculaPut> DeletaMatriculaPorId(int id);
    }
}
