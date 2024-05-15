using AutoMapper;
using PlataformaCursos.Application.DTOs.Capitulo;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;

namespace PlataformaCursos.Application.Services
{
    public class CapituloService : ICapituloService
    {
        private readonly ICapituloRepository _repository;
        private readonly IMapper _mapper;

        public CapituloService(ICapituloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CapituloPost> AdicionaCapitulo(CapituloPost capitulo)
        {
            var capituloPost = _mapper.Map<TblCapitulo>(capitulo);
            var capituloIncluido = await _repository.PostCapitulo(capituloPost);
            return _mapper.Map<CapituloPost>(capituloIncluido);
        }

        public async Task<CapituloPut> AtualizaCapitulo(CapituloPut capitulo)
        {
            var capituloPut = _mapper.Map<TblCapitulo>(capitulo);
            var capituloAlterado = await _repository.PutCapitulo(capituloPut);
            return _mapper.Map<CapituloPut>(capituloAlterado);
        }

        public async Task<IEnumerable<CapituloGet>> BuscaCapitulo(int cursoId)
        {
            var capitulos = await _repository.GetAllCapitulo(cursoId);
            var capitulosGet = _mapper.Map<IEnumerable<CapituloGet>>(capitulos);
            return capitulosGet;
        }

        public async Task<CapituloGet> BuscaCapituloPorId(int id)
        {
            var capitulos = await _repository.GetCapituloById(id);
            var capitulosGet = _mapper.Map<CapituloGet>(capitulos);
            return capitulosGet;
        }

        public async Task<CapituloPut> DeletaCapituloPorId(int id)
        {
            var capitulo = await _repository.DeleteCapituloById(id);
            return _mapper.Map<CapituloPut>(capitulo);
        }
    }
}
