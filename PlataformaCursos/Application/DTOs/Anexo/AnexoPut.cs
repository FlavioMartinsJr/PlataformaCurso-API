using PlataformaCursos.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Anexo
{
    public class AnexoPut
    {
        
        public int Id { get;  set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get;  set; } = null!;

        
        public string? ArquivoUrl { get;  set; }
        [JsonIgnore]
        public int? CursoId { get;  set; }

        [JsonIgnore]
        public DateTime? DataCriacao { get;  set; }

        [Required(ErrorMessage = "A DataAlteracao é obrigatório")]
        public DateTime? DataAlteracao { get;  set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCurso? Curso { get;  set; }
    }
}
