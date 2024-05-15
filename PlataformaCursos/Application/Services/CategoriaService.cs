using AutoMapper;
using PlataformaCursos.Application.DTOs.Categoria;
using PlataformaCursos.Application.DTOs.Curso;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;

namespace PlataformaCursos.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaPost> AdicionaCategoria(CategoriaPost categoria)
        {
            var categoriaPost= _mapper.Map<TblCategoria>(categoria);
            var categoriaIncluido = await _repository.PostCategoria(categoriaPost);
            return _mapper.Map<CategoriaPost>(categoriaIncluido);
        }

        public async Task<CategoriaPut> AtualizaCategoria(CategoriaPut categoria)
        {
            var categoriaPut = _mapper.Map<TblCategoria>(categoria);
            var categoriaAlterado = await _repository.PutCategoria(categoriaPut);
            return _mapper.Map<CategoriaPut>(categoriaAlterado);
        }

        public async Task<IEnumerable<CategoriaGet>> BuscaCategoria()
        {
            var categorias = await _repository.GetAllCategoria();
            var categoriaGet = _mapper.Map<IEnumerable<CategoriaGet>>(categorias);
            return categoriaGet;
        }

        public async Task<CategoriaGet> BuscaCategoriaPorNome(string nome)
        {
            var categoriaGet = await _repository.GetCategoriaByNome(nome);
            return _mapper.Map<CategoriaGet>(categoriaGet);
        }
        public async Task<CategoriaGet> BuscaCategoriaPorId(int id)
        {
            var categoriaGet = await _repository.GetCategoriaById(id);
            return _mapper.Map<CategoriaGet>(categoriaGet);
        }

        public async Task<CategoriaPut> DeletaCategoriaPorId(int id)
        {
            var categoria = await _repository.DeleteCategoriaById(id);
            return _mapper.Map<CategoriaPut>(categoria);
        }
    }
}
