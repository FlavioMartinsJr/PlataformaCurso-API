using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;
using PlataformaCursos.Domain.Pagination;
using PlataformaCursos.Infrastructure.Data.Context;
using PlataformaCursos.Infrastructure.Data.Helpers;

namespace PlataformaCursos.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<TblUsuario>> GetAllUsuario(int pageNumber, int pageSize)
        {
            var query = _context.Usuario.Where(x => x.Ativo == true).OrderBy(x => x.Id).AsQueryable();
            var usuarios =  await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
            return usuarios;
        }

        public async Task<TblUsuario> GetUsuarioById(int id)
        {
            var query = await _context.Usuario.Where(x => x.Ativo == true).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return query!;
        }
        public async Task<TblUsuario> GetUsuarioByEmail(string email)
        {
            var query = await _context.Usuario.Where(x => x.Ativo == true).AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
            return query!;
        }

        public async Task<bool> isExistUsuario()
        {
            return await _context.Usuario.AnyAsync();
        }

        public async Task<TblUsuario> PostUsuario(TblUsuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<TblUsuario> PutUsuario(TblUsuario usuario)
        {

            if (usuario.SenhaHash == null || usuario.SenhaSalt == null)
            {
                var senhaCripgrafado = await _context.Usuario.Where(x => x.Id == usuario.Id).Select(x => new { x.SenhaHash, x.SenhaSalt }).FirstOrDefaultAsync();
                usuario.UpdateSenha(senhaCripgrafado!.SenhaHash, senhaCripgrafado.SenhaSalt);
            }

            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<TblUsuario> DeleteUsuarioById(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                usuario.Delete();
                _context.Usuario.Update(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }

            return null!;
        }
    }
}
