using PlataformaCursos.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Capitulo
{
    public class CapituloPost
    {
        [JsonIgnore]
        public int Id { get;  set; }

        [Required(ErrorMessage = "O Titulo é obrigatório")]
        public string Titulo { get;  set; } = null!;

        [Required(ErrorMessage = "A Descricao é obrigatório")]
        public string Descricao { get;  set; } = null!;

        public string? VideoUrl { get;  set; }

        [Required(ErrorMessage = "O CursoId é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do CursoId é inválido.")]
        public int? CursoId { get;  set; }

        [Required(ErrorMessage = "A DataCriacao é obrigatório")]
        public DateTime? DataCriacao { get;  set; }

        [Required(ErrorMessage = "A DataAlteracao é obrigatório")]
        public DateTime? DataAlteracao { get;  set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCurso? Curso { get;  set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblMatriculaCapitulo> MatriculaCapitulo { get;  set; } = new List<TblMatriculaCapitulo>();
    }
}
