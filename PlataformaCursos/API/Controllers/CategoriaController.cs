using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaCursos.API.Extensions;
using PlataformaCursos.API.Models;
using PlataformaCursos.Application.DTOs.Categoria;
using PlataformaCursos.Application.DTOs.Curso;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Application.Services;
using PlataformaCursos.Domain.Pagination;
using PlataformaCursos.Infrastructure.IOC;
using System.Net;

namespace PlataformaCursos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IUsuarioService _usuarioService;
        public CategoriaController(ICategoriaService categoriaService, IUsuarioService usuarioService)
        {
            _categoriaService = categoriaService;
            _usuarioService = usuarioService;
        }

        [HttpGet("/Categoria/BuscarCategoria")]
        public async Task<ActionResult> BuscarCategoria()
        {
            IEnumerable<CategoriaGet> categoriaGet = await _categoriaService.BuscaCategoria();
            if (categoriaGet.Count() == 0)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhuma Categoria foi encontrada")); ;
            }

            return Ok(categoriaGet);
        }

        [HttpGet("/Categoria/BuscarCategoriaId/{id}")]
        public async Task<ActionResult> BuscarCategoriaId(int id)
        {
            CategoriaGet categoriaGet = await _categoriaService.BuscaCategoriaPorId(id);
            if (categoriaGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhuma Categoria foi encontrada")); ;
            }
            return Ok(categoriaGet);
        }
        [HttpGet("/Categoria/BuscarCategoriaNome/{nome}")]
        public async Task<ActionResult> BuscarCategoria(string nome)
        {
            CategoriaGet categoriaGet = await _categoriaService.BuscaCategoriaPorNome(nome);
            if (categoriaGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhuma Categoria foi encontrada")); ;
            }

            return Ok(categoriaGet);
        }

        [Authorize]
        [HttpPost("/Categoria/IncluirCategoria")]
        public async Task<ActionResult> IncluirCategoria(CategoriaPost categoriaPost)
        {
            var userId = User.GetId();
            var userAuth = await _usuarioService.BuscaUsuarioPorId(userId);

            if(userAuth == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Usuario não encontrado"));
            }

            if(!userAuth.IsAdmin)
            {
                return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Usuario não tem permissão"));
            }

            CategoriaPost categoriaResult = await _categoriaService.AdicionaCategoria(categoriaPost);
            if(categoriaResult == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Falha a adicionar categoria"));
            }
            return Ok(new ResponseModel(HttpStatusCode.OK, "Categoria criada com Sucesso"));
        }

        [Authorize]
        [HttpPut("/Categoria/AtualizarCategoria")]
        public async Task<ActionResult> AtualizarCategoria(CategoriaPut categoriaPut)
        {
            var userId = User.GetId();
            var userAuth = await _usuarioService.BuscaUsuarioPorId(userId);

            if (userAuth == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Usuario não encontrado"));
            }

            if (!userAuth.IsAdmin)
            {
                return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Usuario não tem permissão"));
            }

            CategoriaGet categoriaGet = await _categoriaService.BuscaCategoriaPorId(categoriaPut.Id);
            if(categoriaGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Categoria não encontrada"));
            }

            CategoriaPut categoriaResult = await _categoriaService.AtualizaCategoria(categoriaPut);
            if (categoriaResult == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Falha a atualizar categoria"));
            }
            return Ok(new ResponseModel(HttpStatusCode.OK, "Categoria Alterada com Sucesso"));
        }

        [Authorize]
        [HttpDelete("/Categoria/DeletarCategoria/{id}")]
        public async Task<ActionResult> DeletarCategoria(int id)
        {
            var userId = User.GetId();
            var userAuth = await _usuarioService.BuscaUsuarioPorId(userId);

            if (userAuth == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Usuario não encontrado"));
            }

            if (!userAuth.IsAdmin)
            {
                return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Usuario não tem permissão"));
            }

            var categoriaDelete = await _categoriaService.DeletaCategoriaPorId(id);
            if (categoriaDelete == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Categoria não encontrada"));
            }
            return Ok(new ResponseModel(HttpStatusCode.OK, "Categoria deletada com Sucesso"));
        }
    }
}
