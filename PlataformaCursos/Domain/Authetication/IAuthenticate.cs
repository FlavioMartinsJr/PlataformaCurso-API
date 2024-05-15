using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Domain.Authetication
{
    public interface IAuthenticate
    {
        Task<bool> Authenticated(string email, string senha);
        Task<bool> UserExists(string email);
        public (string, DateTime) GenerateToken(int id, string email);
        public Task<TblUsuario> GetUserByEmail(string email);
    }
}
