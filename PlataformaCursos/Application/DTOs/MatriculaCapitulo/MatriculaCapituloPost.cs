using PlataformaCursos.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.MatriculaCapitulo
{
    public class MatriculaCapituloPost
    {
        [JsonIgnore]
        public int Id { get; private set; }

        [Required(ErrorMessage = "O Completo é obrigatório")]
        public bool Completo { get; set; }

        [Required(ErrorMessage = "O MatriculaId é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do MatriculaId é inválido.")]
        public int MatriculaId { get; private set; }

        [Required(ErrorMessage = "O CapituloId é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do CapituloId é inválido.")]
        public int CapituloId { get; private set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCapitulo Capitulo { get; private set; } = null!;

        [JsonIgnore]
        [IgnoreDataMember]
        public TblMatricula Matricula { get; private set; } = null!;

    }
}
