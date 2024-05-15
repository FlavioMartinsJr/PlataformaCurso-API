using PlataformaCursos.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.CursoCategoria
{
    public class CursoCategoriaPost
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "O CursoId é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do CursoId é inválido.")]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "O CategoriaId é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do CategoriaId é inválido.")]
        public int CategoriaId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCategoria Categoria { get; set; } = null!;

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCurso Curso { get; set; } = null!;
    }
}
