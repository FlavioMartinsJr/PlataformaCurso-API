using System.ComponentModel.DataAnnotations;

namespace PlataformaCursos.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = null!;
    }
}
