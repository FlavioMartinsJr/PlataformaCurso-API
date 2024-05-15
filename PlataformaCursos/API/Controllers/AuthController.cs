using Microsoft.AspNetCore.Mvc;
using PlataformaCursos.API.Models;
using PlataformaCursos.Application.DTOs.Curso;
using PlataformaCursos.Application.DTOs.Usuario;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Domain.Authetication;
using PlataformaCursos.Domain.Pagination;
using PlataformaCursos.Infrastructure.IOC;
using System.Net;

namespace PlataformaCursos.API.Controllers
{
    [ApiController]
    [Route("Api/Usuario")]
    public class AuthController : Controller
    {
        private readonly IAuthenticate _authenticate;
        private readonly IUsuarioService _usuarioService;
        public AuthController(IAuthenticate authenticate, IUsuarioService usuarioService)
        {
            _authenticate = authenticate;
            _usuarioService = usuarioService;
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<UserToken>> RegistrarUsuario(UsuarioPost usuario)
        {
         
            if (usuario == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Dados Inválidos"));
            }

            var emailExiste = await _authenticate.UserExists(usuario.Email);
            if (emailExiste)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Email já estar Registrado"));
            }

            var usuarioNovo = await _usuarioService.AdicionaUsuario(usuario);
            if (usuarioNovo == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Erro ao registrar"));
            }

            var token = _authenticate.GenerateToken(usuarioNovo.Id, usuarioNovo.Email);
            return new UserToken
            {
                Token = token.Item1,
                TempoToken = token.Item2,
                Email = usuarioNovo.Email,

            };

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> LogarUsuario(LoginModel loginModel)
        {
            var existe = await _authenticate.UserExists(loginModel.Email);
            if (!existe)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.Unauthorized, "Usuário não existe"));
            }

            var result = await _authenticate.Authenticated(loginModel.Email, loginModel.Senha);
            if (!result)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.Unauthorized, "Usuário ou senha inválido"));
            }

            var usuario = await _authenticate.GetUserByEmail(loginModel.Email);


            var token = _authenticate.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token.Item1,
                TempoToken = token.Item2,
                Email = usuario.Email
            };
        }
    }
}
