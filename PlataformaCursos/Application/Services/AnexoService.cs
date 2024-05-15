using AutoMapper;
using PlataformaCursos.Application.DTOs.Anexo;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;

namespace PlataformaCursos.Application.Services
{
    public class AnexoService : IAnexoService
    {
        private readonly IAnexoRepository _repository;
        private readonly IMapper _mapper;

        public AnexoService(IAnexoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AnexoPost> AdicionaAnexo(AnexoPost anexo)
        {
            var anexoPost = _mapper.Map<TblAnexo>(anexo);
            var anexoIncluido = await _repository.PostAnexo(anexoPost);
            return _mapper.Map<AnexoPost>(anexoIncluido);
        }

        public async Task<AnexoPut> AtualizaAnexo(AnexoPut anexo)
        {
            var anexoPut = _mapper.Map<TblAnexo>(anexo);
            var anexoAlterado = await _repository.PutAnexo(anexoPut);
            return _mapper.Map<AnexoPut>(anexoAlterado);
        }

        public async Task<IEnumerable<AnexoGet>> BuscaAnexo(int cursoId)
        {
            var anexos = await _repository.GetAllAnexo(cursoId);
            var anexosGet = _mapper.Map<IEnumerable<AnexoGet>>(anexos);
            return anexosGet;
        }

        public async Task<AnexoGet> BuscaAnexoById(int id)
        {
            var anexos = await _repository.GetAnexoById(id);
            var anexosGet = _mapper.Map<AnexoGet>(anexos);
            return anexosGet;
        }

        public async Task<AnexoPut> DeletaAnexoPorId(int id)
        {
            var anexo = await _repository.DeleteAnexoById(id);
            return _mapper.Map<AnexoPut>(anexo);
        }
    }
}
