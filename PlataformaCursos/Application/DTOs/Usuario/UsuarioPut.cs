using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Usuario
{
    public class UsuarioPut
    {
        [Required(ErrorMessage = "essa informação é obrigatória.")]
        public int Id { get;  set; }
        [JsonIgnore]
        [MaxLength(250, ErrorMessage = "O E-mail não pode ter mais de 200 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [JsonIgnore]
        [MinLength(8, ErrorMessage = "A senha deve ter, no mínimo, 8 caracteres.")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Senha { get; set; } = null!;
        [JsonIgnore]
        public bool IsAdmin { get;  set; } = false;
        [Required(ErrorMessage = "essa informação é obrigatória.")]
        public bool IsProfessor { get;  set; } = false;
        [JsonIgnore]
        public bool Ativo { get; set; } = true;

        [JsonIgnore]
        public DateTime? DataCriacao { get;  set; }

        [Required(ErrorMessage = "A DataAlteracao é obrigatória.")]
        public DateTime? DataAlteracao { get;  set; }
    }
}
