using AutoMapper;
using PlataformaCursos.Application.DTOs.Curso;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;
using PlataformaCursos.Domain.Pagination;

namespace PlataformaCursos.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<CursoGet>> BuscaCurso(int pageNumber, int pageSize)
        {
            var cursos = await _repository.GetAllCurso(pageNumber, pageSize);
            var cursosGet = _mapper.Map<IEnumerable<CursoGet>>(cursos);
            return new PagedList<CursoGet>(cursosGet, pageNumber, pageSize, cursos.TotalCount);
        }

        public async Task<PagedList<CursoGet>> BuscaCursoPorFiltro(string categoria, int pageNumber, int pageSize)
        {
            var cursosFiltro = await _repository.GetCursoByFiltroAsync(categoria, pageNumber, pageSize);
            var cursosGet = _mapper.Map<IEnumerable<CursoGet>>(cursosFiltro);
            return new PagedList<CursoGet>(cursosGet, pageNumber, pageSize, cursosFiltro.TotalCount);
        }
        public async Task<PagedList<CursoGet>> BuscaCursoPorTermo(string termo, int pageNumber, int pageSize)
        {
            var cursosFiltro = await _repository.GetCursoByTermoAsync(termo, pageNumber, pageSize);
            var cursosGet = _mapper.Map<IEnumerable<CursoGet>>(cursosFiltro);
            return new PagedList<CursoGet>(cursosGet, pageNumber, pageSize, cursosFiltro.TotalCount);
        }

        public async Task<CursoGet> BuscaCursoPorId(int id)
        {
            var curso = await _repository.GetCursoById(id);
            return _mapper.Map<CursoGet>(curso);
        }

        public async Task<CursoPost> AdicionaCurso(CursoPost cursoPost)
        {
            var curso = _mapper.Map<TblCurso>(cursoPost);
            var cursoAdicionado = await _repository.PostCurso(curso);
            return _mapper.Map<CursoPost>(cursoAdicionado);
        }

        public async Task<CursoPut> AtualizaCurso(CursoPut cursoPut)
        {
            var curso = _mapper.Map<TblCurso>(cursoPut);
            var cursoAlterado = await _repository.PutCurso(curso);
            return _mapper.Map<CursoPut>(cursoAlterado);
        }
        public async Task<CursoPut> DeletaCursoPorId(int id)
        {
            var curso = await _repository.DeleteCursoById(id);
            return _mapper.Map<CursoPut>(curso);
        }

    }
}
