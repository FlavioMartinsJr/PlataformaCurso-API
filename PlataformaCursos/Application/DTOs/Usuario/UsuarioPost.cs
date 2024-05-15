using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Usuario
{
    public class UsuarioPost
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [MaxLength(250, ErrorMessage = "O E-mail não pode ter mais de 200 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve ter, no mínimo, 8 caracteres.")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Senha { get;  set; } = null!;

        public bool IsProfessor { get; set; }
        [JsonIgnore]
        public bool IsAdmin { get; set; } = false;
        [JsonIgnore]
        public bool Ativo { get; set; } = true;

        [Required(ErrorMessage = "A DataAlteracao é obrigatória.")]
        public DateTime? DataCriacao { get; set; }

        [Required(ErrorMessage = "A DataAlteracao é obrigatória.")]
        public DateTime? DataAlteracao { get; set; }
    }
}
