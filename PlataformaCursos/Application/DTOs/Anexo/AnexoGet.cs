using PlataformaCursos.Domain.Entities;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Anexo
{
    public class AnexoGet
    {
        public int Id { get;  set; }

        public string Nome { get;  set; } = null!;

        public string? ArquivoUrl { get;  set; }

        public int? CursoId { get;  set; }

        public DateTime? DataCriacao { get;  set; }

        public DateTime? DataAlteracao { get;  set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCurso? Curso { get;  set; }
    }
}
