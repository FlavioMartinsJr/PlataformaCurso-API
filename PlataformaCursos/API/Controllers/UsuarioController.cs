using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaCursos.API.Extensions;
using PlataformaCursos.API.Models;
using PlataformaCursos.Application.DTOs.Curso;
using PlataformaCursos.Application.DTOs.Usuario;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Application.Services;
using PlataformaCursos.Domain.Authetication;
using PlataformaCursos.Domain.Pagination;
using PlataformaCursos.Infrastructure.IOC;
using System.Net;

namespace PlataformaCursos.API.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController( IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("/Usuario/BuscarUsuario")]
        public async Task<ActionResult> BuscarUsuario([FromQuery] PaginationParams paginationParams)
        {
            var userId = User.GetId();
            var user = await _usuarioService.BuscaUsuarioPorId(userId);

            if (!user.IsAdmin) 
            {
                return Ok(new { Dados=user , Mensagem = "Sem permissão para consultar outros usuarios"});
            }

            PagedList<UsuarioGet> usuarioGet = await _usuarioService.BuscaUsuario(paginationParams.NumeroPagina, paginationParams.ItemsPagina);
            if (usuarioGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhum Usuario foi encontrado.")); ;
            }
            PaginationModel paginationModel = new PaginationModel(usuarioGet.CurrentPage, usuarioGet.PageSize, usuarioGet.TotalCount, usuarioGet.TotalPages);
            Response.AddPaginationHeader(paginationModel);
            ResponsePagination<PagedList<UsuarioGet>> response = new ResponsePagination<PagedList<UsuarioGet>>(usuarioGet, paginationModel);
            return Ok(response);
        }

        [HttpGet("/Usuario/BuscarUsuarioId/{id}")]
        public async Task<ActionResult<UserToken>> BuscarUsuarioId(int id)
        {
            var userId = User.GetId();
            var user = await _usuarioService.BuscaUsuarioPorId(userId);
            if (id == 0)
            {
                id = userId;
            }

            if(!user.IsAdmin && user.Id != id)
            {
                return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Você não tem permissão"));
                
            }

            var usuario = await _usuarioService.BuscaUsuarioPorId((int)id);
            if (usuario == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.NotFound, "Usuario  não encontrado"));
            }

            return Ok(usuario);

        }

        [HttpGet("/Usuario/BuscarUsuarioEmail/{email}")]
        public async Task<ActionResult<UserToken>> BuscarUsuarioEmail(string email)
        {
            var userEmail = User.GetEmail();
            
            var user = await _usuarioService.BuscaUsuarioPorEmail(email);

            if (user == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.NotFound, "Usuario não Encontrado"));
            }

            if (userEmail != user.Email)
            {
                if (!user.IsAdmin)
                {
                    return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Você não tem permissão para ver outros Usuarios"));
                }
            }

            return Ok(user);

        }
        [HttpPut("/Usuario/AtualizarUsuario")]
        public async Task<ActionResult> AtualizarCurso([FromBody] UsuarioPut usuarioPut)
        {

            var userId = User.GetId();

            var user = await _usuarioService.BuscaUsuarioPorId(userId);

            if (user == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.NotFound, "Aconteceu algum problema para atualizar o usuario"));
            }

            if (!user.IsAdmin && usuarioPut.Id != user.Id)
            {
                return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Você não tem permissão para Incluir um Curso"));
            }

            var usuarioBuscado = await _usuarioService.BuscaUsuarioPorId(usuarioPut.Id);
            if(usuarioBuscado == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.NotFound, "Usuario não foi encontrado"));
            }
            usuarioPut.Id = usuarioBuscado.Id;
            usuarioPut.Email = usuarioBuscado.Email;
            usuarioPut.Ativo = usuarioBuscado.Ativo;
            usuarioPut.IsAdmin = usuarioBuscado.IsAdmin;
            usuarioPut.DataCriacao = usuarioBuscado.DataCriacao;

            var usuarioAlterado = await _usuarioService.AtualizaUsuario(usuarioPut);

            if (usuarioAlterado == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Ocorreu um erro ao Atualizar o Curso."));
            }
            
            return Ok(new ResponseModel(HttpStatusCode.OK, "Usuario Alterado com Sucesso!"));
        }

        [HttpDelete("/Usuario/DeletarUsuario/{id}")]
        public async Task<ActionResult> DeletarUsuario(int id)
        {
            var userId = User.GetId();

            var user = await _usuarioService.BuscaUsuarioPorId(userId);

            if (user == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Usuario invalido"));
            }

            if (!user.IsAdmin && id != user.Id)
            {
                return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Você não tem permissão para Deletar um Curso"));
            }

            var usuario = await _usuarioService.DeletaUsuarioPorId(id);

            if (usuario == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Ocorreu um erro ao Atualizar o Curso."));
            }

            return Ok(new ResponseModel(HttpStatusCode.OK, "Usuario Deletado com Sucesso!"));

        }
    }
}
