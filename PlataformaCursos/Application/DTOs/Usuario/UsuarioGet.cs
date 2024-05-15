using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Usuario
{
    public class UsuarioGet
    {
        public int Id { get; private set; }

        public string Email { get; private set; } = null!;

        [NotMapped]
        public string Senha { get; private set; } = null!;

        public bool IsProfessor { get;  set; } = false;
        [JsonIgnore]
        public bool IsAdmin { get; set; } = false;

        public bool Ativo { get; private set; } = true;

        public DateTime? DataCriacao { get; private set; }

        public DateTime? DataAlteracao { get;  set; }

    }
}
