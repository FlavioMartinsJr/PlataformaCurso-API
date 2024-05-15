using PlataformaCursos.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Anexo
{
    public class AnexoPost
    {

        [JsonIgnore]
        public int Id { get;  set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get;  set; } = null!;

        public string? ArquivoUrl { get;  set; }

        [Required(ErrorMessage = "O CursoId é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do CursoId é inválido.")]
        public int? CursoId { get;  set; }

        [Required(ErrorMessage = "O DataCriacao é obrigatório")]
        public DateTime? DataCriacao { get;  set; }

        [Required(ErrorMessage = "O DataAlteracao é obrigatório")]
        public DateTime? DataAlteracao { get;  set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCurso? Curso { get;  set; }
    }
}
