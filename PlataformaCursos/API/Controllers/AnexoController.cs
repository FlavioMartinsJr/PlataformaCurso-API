using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaCursos.API.Models;
using PlataformaCursos.Application.DTOs.Anexo;
using PlataformaCursos.Application.DTOs.Categoria;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Application.Services;
using PlataformaCursos.Infrastructure.IOC;
using System.Net;

namespace PlataformaCursos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnexoController : Controller
    {
        private readonly IAnexoService _anexoService;
        private readonly IUsuarioService _usuarioService;
        public AnexoController(IAnexoService anexoService, IUsuarioService usuarioService)
        {
            _anexoService = anexoService;
            _usuarioService = usuarioService;
        }

        [HttpGet("/Anexo/BuscarAnexo/{cursoId}")]
        public async Task<ActionResult> BuscarAnexo(int cursoId)
        {
            IEnumerable<AnexoGet> anexoGet = await _anexoService.BuscaAnexo(cursoId);
            if (anexoGet.Count() == 0)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhuma anexo foi encontrado")); ;
            }

            return Ok(anexoGet);
        }

        [HttpGet("/Anexo/BuscarAnexoId/{id}")]
        public async Task<ActionResult> BuscarAnexoId(int id)
        {
            AnexoGet anexoGet = await _anexoService.BuscaAnexoById(id);
            if (anexoGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhuma anexo foi encontrado")); ;
            }

            return Ok(anexoGet);
        }

        [HttpPost("/Anexo/IncluirAnexo/")]
        [Authorize]
        public async Task<ActionResult> IncluirAnexo([FromBody] AnexoPost anexoPost)
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

            AnexoPost anexo = await _anexoService.AdicionaAnexo(anexoPost);
            if (anexo == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Falha ao adicionar anexo"));
            }

            return Ok(new ResponseModel(HttpStatusCode.OK, "Anexo criado com Sucesso"));
        }

        [HttpPut("/Anexo/AtualizarAnexo/")]
        [Authorize]
        public async Task<ActionResult> AtualizarAnexo([FromBody] AnexoPut anexoPut)
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

            AnexoGet anexoGet = await _anexoService.BuscaAnexoById(anexoPut.Id);
            if (anexoGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Anexo não encontrada"));
            }

            anexoPut.DataCriacao = anexoGet.DataCriacao;
            anexoPut.CursoId = anexoGet.CursoId;
            anexoPut.Id = anexoGet.Id;

            AnexoPut anexoAlterado = await _anexoService.AtualizaAnexo(anexoPut);
            if (anexoAlterado == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Falha ao atualizar o anexo"));
            }
            return Ok(new ResponseModel(HttpStatusCode.OK, "Anexo alterada com sucesso"));
        }

       
        [HttpDelete("/Anexo/DeletarAnexo/{id}")]
        [Authorize]
        public async Task<ActionResult> DeletarAnexo(int id)
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

            var anexoDelete = await _anexoService.DeletaAnexoPorId(id);
            if (anexoDelete == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Anexo não encontrado"));
            }
            return Ok(new ResponseModel(HttpStatusCode.OK, "Anexo deletado com Sucesso"));
        }
    }
}
