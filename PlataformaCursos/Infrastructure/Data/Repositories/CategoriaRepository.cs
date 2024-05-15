using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;
using PlataformaCursos.Infrastructure.Data.Context;
using PlataformaCursos.Infrastructure.Data.Helpers;

namespace PlataformaCursos.Infrastructure.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TblCategoria> DeleteCategoriaById(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            
            if(categoria != null)
            {
                _context.Categoria.Remove(categoria);
                await _context.SaveChangesAsync();
            }
           
            return categoria!;
        }

        public async Task<IEnumerable<TblCategoria>> GetAllCategoria()
        {
            var query = await _context.Categoria.OrderBy(x => x.Id).ToListAsync();
            return query;
        }
        public async Task<TblCategoria> GetCategoriaById(int id)
        {
            var categoria = await _context.Categoria.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return categoria!;
        }
        public async Task<TblCategoria> GetCategoriaByNome(string nome)
        {
            var categoria = await _context.Categoria.Where(x => x.Nome == nome).AsNoTracking().FirstOrDefaultAsync(x => x.Nome == nome);
            return categoria!;
        }

        public async Task<TblCategoria> PostCategoria(TblCategoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<TblCategoria> PutCategoria(TblCategoria categoria)
        {
            _context.Categoria.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}
