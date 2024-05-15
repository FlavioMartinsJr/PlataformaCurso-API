using AutoMapper;
using PlataformaCursos.Application.DTOs.Capitulo;
using PlataformaCursos.Application.DTOs.Matricula;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;

namespace PlataformaCursos.Application.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _repository;
        private readonly IMapper _mapper;

        public MatriculaService(IMatriculaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MatriculaPost> AdicionaMatricula(MatriculaPost matriculaPost)
        {
            var matricula = _mapper.Map<TblMatricula>(matriculaPost);
            var matriculaIncluido = await _repository.PostMatricula(matricula);
            return _mapper.Map<MatriculaPost>(matriculaIncluido);
        }

        public async Task<IEnumerable<MatriculaGet>> BuscaMatricula(int usuarioId)
        {
            var matricula = await _repository.GetAllMatricula(usuarioId);
            var matriculaGet = _mapper.Map<IEnumerable<MatriculaGet>>(matricula);
            return matriculaGet;
        }

        public async Task<MatriculaGet> BuscaMatriculaPorId(int id)
        {
            var matricula = await _repository.GetMatriculaById(id);
            var matriculaGet = _mapper.Map<MatriculaGet>(matricula);
            return matriculaGet;
        }

        public async Task<MatriculaPut> DeletaMatriculaPorId(int id)
        {
            var matricula = await _repository.DeleteMatriculaById(id);
            return _mapper.Map<MatriculaPut>(matricula);
        }
    }
}
