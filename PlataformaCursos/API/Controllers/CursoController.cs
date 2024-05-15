using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaCursos.API.Extensions;
using PlataformaCursos.API.Models;
using PlataformaCursos.Application.DTOs.Curso;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Application.Services;
using PlataformaCursos.Domain.Authetication;
using PlataformaCursos.Domain.Pagination;
using PlataformaCursos.Infrastructure.IOC;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace PlataformaCursos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;
        private readonly IUsuarioService _usuarioService;
        public CursoController(ICursoService cursoService, IUsuarioService usuarioService)
        {
            _cursoService = cursoService;
            _usuarioService = usuarioService;
        }

        [HttpGet("/Curso/BuscarCurso")]
        public async Task<ActionResult> BuscarCursos([FromQuery] PaginationParams paginationParams)
        {

            PagedList<CursoGet> cursoGet = await _cursoService.BuscaCurso(paginationParams.NumeroPagina, paginationParams.ItemsPagina);
            if (cursoGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhum Curso foi encontrado.")); ;
            }
            PaginationModel paginationModel = new PaginationModel(cursoGet.CurrentPage, cursoGet.PageSize, cursoGet.TotalCount, cursoGet.TotalPages);
            Response.AddPaginationHeader(paginationModel);
            ResponsePagination<PagedList<CursoGet>> response = new ResponsePagination<PagedList<CursoGet>>(cursoGet, paginationModel);
            return Ok(response);
        }

        [HttpGet("/Curso/BuscarCursoFiltro")]
        public async Task<ActionResult> BuscarCursosFiltro([FromQuery] string categoria, [FromQuery] PaginationParams paginationParams)
        {
            var cursoFiltroGet = await _cursoService.BuscaCursoPorFiltro(categoria, paginationParams.NumeroPagina, paginationParams.ItemsPagina);
            if (cursoFiltroGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhum Curso foi encontrado.")); ;
            }
            PaginationModel paginationModel = new PaginationModel(cursoFiltroGet.CurrentPage, cursoFiltroGet.PageSize, cursoFiltroGet.TotalCount, cursoFiltroGet.TotalPages);
            Response.AddPaginationHeader(paginationModel);
            ResponsePagination<PagedList<CursoGet>> response = new ResponsePagination<PagedList<CursoGet>>(cursoFiltroGet, paginationModel);
            return Ok(response);
        }

        [HttpGet("/Curso/BuscarCursoTermo")]
        public async Task<ActionResult> BuscarCursoTermo([FromQuery] TermoModel termoModel)
        {
            var cursoFiltroGet = await _cursoService.BuscaCursoPorTermo(termoModel.Termo, termoModel.PageNumber, termoModel.PageSize);
            PaginationModel paginationModel = new PaginationModel(cursoFiltroGet.CurrentPage, cursoFiltroGet.PageSize, cursoFiltroGet.TotalCount, cursoFiltroGet.TotalPages);
            Response.AddPaginationHeader(paginationModel);
            ResponsePagination<PagedList<CursoGet>> response = new ResponsePagination<PagedList<CursoGet>>(cursoFiltroGet, paginationModel);
            return Ok(response);
        }

        [HttpGet("/Curso/BuscarCursoId/{id}")]
        public async Task<ActionResult> BuscarId(int id)
        {
            var cursoGet = await _cursoService.BuscaCursoPorId(id);
            if (cursoGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhum Curso foi encontrado.")); ;
            }

            return Ok(cursoGet);
        }

        [HttpPost("/Curso/IncluirCurso")]
        [Authorize]
        public async Task<ActionResult> IncluirCurso([FromBody] CursoPost cursoPost)
        {

            var userId = User.GetId();

            var user = await _usuarioService.BuscaUsuarioPorId(userId);

            if (user == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Usuario invalido"));
            }
            cursoPost.UsuarioId = user.Id;

            if (!user.IsProfessor)
            {
                if (!user.IsAdmin)
                {
                    return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Você não tem permissão para Incluir um Curso"));
                }
            }

            var curso = await _cursoService.AdicionaCurso(cursoPost);

            if (curso == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Ocorreu um erro ao Criar o Curso."));
            }
            return Ok(new ResponseModel(HttpStatusCode.OK, "Curso Criado com Sucesso!"));
        }

        [HttpPut("/Curso/AtualizarCurso")]
        [Authorize]
        public async Task<ActionResult> AtualizarCurso([FromBody] CursoPut cursoPut)
        {

            var userId = User.GetId();

            var user = await _usuarioService.BuscaUsuarioPorId(userId);

            if (user == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Usuario invalido"));
            }

            CursoGet cursoGet = await _cursoService.BuscaCursoPorId(cursoPut.Id);

            if (cursoGet == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.NotFound, "Curso não existe"));
            }

            if (userId != cursoGet.UsuarioId)
            {
                if (!user.IsAdmin)
                {
                    return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Você não tem permissão para alterar outros Cursos"));
                }
            }

            cursoPut.UsuarioId = cursoGet.UsuarioId;
            cursoPut.DataCriacao = cursoGet.DataCriacao;

            var cursoAlterado = await _cursoService.AtualizaCurso(cursoPut);

            if (cursoAlterado == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Ocorreu um erro ao Atualizar o Curso."));
            }
            return Ok(new ResponseModel(HttpStatusCode.OK, "Curso Alterado com Sucesso!"));
        }

        [HttpDelete("/Curso/DeletarCurso/{id}")]
        [Authorize]
        public async Task<ActionResult> DeletarCurso(int id)
        {
            var userId = User.GetId();

            var user = await _usuarioService.BuscaUsuarioPorId(userId);

            if (user == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Usuario invalido"));
            }

            CursoGet cursoGet = await _cursoService.BuscaCursoPorId(id);

            if (cursoGet == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.NotFound, "Curso não existe"));
            }

            if (cursoGet.UsuarioId != userId)
            {
                if (!user.IsAdmin)
                {
                    return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Você não tem permissão para Deletar um Curso"));
                }
            }

            var cursoAlterado = await _cursoService.DeletaCursoPorId(id);

            if (cursoAlterado == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Ocorreu um erro ao Atualizar o Curso."));
            }

            return Ok(new ResponseModel(HttpStatusCode.OK, "Curso Deletado com Sucesso!"));

        }
    }
}
