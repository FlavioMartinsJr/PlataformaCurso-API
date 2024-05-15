using PlataformaCursos.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Matricula
{
    public class MatriculaPut
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do Id passando (0) representa o usuario autenticado")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O UsuarioId é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do UsuarioId é inválido.")]
        public int? UsuarioId { get; set; }

        [Required(ErrorMessage = "O CursoId é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do CursoId é inválido.")]
        public int? CursoId { get; set; }

        [JsonIgnore]
        public DateTime? DataCriacao { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCurso Curso { get; set; } = null!;

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblMatriculaCapitulo> MatriculaCapitulo { get; set; } = new List<TblMatriculaCapitulo>();

        [JsonIgnore]
        [IgnoreDataMember]
        public TblUsuario Usuario { get; set; } = null!;
    }
}
