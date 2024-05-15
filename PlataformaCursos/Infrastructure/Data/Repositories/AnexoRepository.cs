using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;
using PlataformaCursos.Infrastructure.Data.Context;

namespace PlataformaCursos.Infrastructure.Data.Repositories
{
    public class AnexoRepository : IAnexoRepository
    {
        private readonly ApplicationDbContext _context;

        public AnexoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TblAnexo> DeleteAnexoById(int id)
        {
            var query = await _context.Anexo.FindAsync(id);

            if (query != null)
            {
                _context.Anexo.Remove(query);
                await _context.SaveChangesAsync();
            }

            return query!;
        }

        public async Task<IEnumerable<TblAnexo>> GetAllAnexo(int cursoId)
        {
            var query = from anexo in _context.Anexo
                        join curso in _context.Curso
                        on anexo.CursoId equals curso.Id
                        where curso.Ativo == true && anexo.CursoId == cursoId
                        select anexo;
            return await query.ToListAsync();
        }

        public async Task<TblAnexo> GetAnexoById(int id)
        {
            var query = await _context.Anexo.FindAsync(id);
            return query!;
        }

        public async Task<TblAnexo> PostAnexo(TblAnexo anexo)
        {
            var query = await _context.Curso.FindAsync(anexo.CursoId);

            if (query != null)
            {
                _context.Anexo.Add(anexo);
                await _context.SaveChangesAsync();
                return anexo!;
            }
            return null!;
        }
        public async Task<TblAnexo> PutAnexo(TblAnexo anexo)
        {
            var query = await _context.Anexo.FindAsync(anexo.Id);
            
            if(query != null)
            {
                query.Nome = anexo.Nome;
                query.ArquivoUrl = anexo.ArquivoUrl;
                query.DataAlteracao = anexo.DataAlteracao;
                await _context.SaveChangesAsync();
            }
            return query!;

        }
    }
   
}
