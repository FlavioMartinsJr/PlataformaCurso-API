using AutoMapper;
using PlataformaCursos.Application.DTOs.Usuario;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;
using PlataformaCursos.Domain.Pagination;
using PlataformaCursos.Infrastructure.Data.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace PlataformaCursos.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioPost> AdicionaUsuario(UsuarioPost usuarioPost)
        {
            EmailAddressHelper helper = new EmailAddressHelper();
            var usuario = _mapper.Map<TblUsuario>(usuarioPost);

            if (!helper.IsValid(usuarioPost.Email))
            {
                return null!;
            }

            if (usuarioPost.Senha != null)
            {
                using var hmac = new HMACSHA512();
                byte[] senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioPost.Senha));
                byte[] senhaSalt = hmac.Key;

                usuario.UpdateSenha(senhaHash, senhaSalt);
               
            }

            var usuarioIncluido = await _repository.PostUsuario(usuario);
            return _mapper.Map<UsuarioPost>(usuarioIncluido);

        }

        public async Task<UsuarioPut> AtualizaUsuario(UsuarioPut usuarioPut)
        {
            var usuario = _mapper.Map<TblUsuario>(usuarioPut);

            if (usuarioPut.Senha != null)
            {
                using var hmac = new HMACSHA512();
                byte[] senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioPut.Senha));
                byte[] senhaSalt = hmac.Key;
                usuario.UpdateSenha(senhaHash, senhaSalt);
              
            }

            var usuarioAlterado = await _repository.PutUsuario(usuario);
            return _mapper.Map<UsuarioPut>(usuarioAlterado);
        }

        public async Task<PagedList<UsuarioGet>> BuscaUsuario(int pageNumber, int pageSize)
        {
            var usuarios = await _repository.GetAllUsuario(pageNumber, pageSize);
            var usuarioGet = _mapper.Map<IEnumerable<UsuarioGet>>(usuarios);
            return new PagedList<UsuarioGet>(usuarioGet, pageNumber, pageSize, usuarios.TotalCount);
        }

        public async Task<UsuarioGet> BuscaUsuarioPorId(int id)
        {
            var usuario = await _repository.GetUsuarioById(id);
            return _mapper.Map<UsuarioGet>(usuario);
        }
        public async Task<UsuarioGet> BuscaUsuarioPorEmail(string email)
        {
            var usuario = await _repository.GetUsuarioByEmail(email);
            return _mapper.Map<UsuarioGet>(usuario);
        }

        public async Task<bool> ExisteUsuario()
        {
            return await _repository.isExistUsuario();
        }
        public async Task<UsuarioPut> DeletaUsuarioPorId(int id)
        {
            var usuario = await _repository.DeleteUsuarioById(id);
            return _mapper.Map<UsuarioPut>(usuario);
        }
    }
}
