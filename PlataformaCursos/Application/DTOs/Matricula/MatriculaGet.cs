using PlataformaCursos.Domain.Entities;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Matricula
{
    public class MatriculaGet
    {
        public int Id { get;  set; }

        public int? UsuarioId { get;  set; }

        public int? CursoId { get;  set; }

        public DateTime? DataCriacao { get;  set; }

        public DateTime? DataAlteracao { get;  set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCurso Curso { get;  set; } = null!;

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblMatriculaCapitulo> MatriculaCapitulo { get;  set; } = new List<TblMatriculaCapitulo>();

        [JsonIgnore]
        [IgnoreDataMember]
        public TblUsuario Usuario { get;  set; } = null!;

    }
}
