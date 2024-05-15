using PlataformaCursos.Domain.Entities;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Capitulo
{
    public class CapituloGet
    {
        public int Id { get;  set; }

        public string Titulo { get;  set; } = null!;

        public string Descricao { get;  set; } = null!;

        public string? VideoUrl { get;  set; }

        public int? CursoId { get;  set; }

        public DateTime? DataCriacao { get;  set; }

        public DateTime? DataAlteracao { get;  set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCurso? Curso { get;  set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblMatriculaCapitulo> MatriculaCapitulo { get;  set; } = new List<TblMatriculaCapitulo>();
    }
}
