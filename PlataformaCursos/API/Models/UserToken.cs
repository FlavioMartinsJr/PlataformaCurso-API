namespace PlataformaCursos.API.Models
{
    public class UserToken
    {
        public string Token { get; set; } = null!;
        public DateTime TempoToken { get; set; }
        public string Email { get; set; } = null!;
    }
}
