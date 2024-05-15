using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaCursos.API.Models;
using PlataformaCursos.Application.DTOs.Capitulo;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Infrastructure.IOC;
using System.Net;

namespace PlataformaCursos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CapituloController : Controller
    {
        private readonly ICapituloService _capituloService;
        private readonly IUsuarioService _usuarioService;
        public CapituloController(ICapituloService capituloService, IUsuarioService usuarioService)
        {
            _capituloService = capituloService;
            _usuarioService = usuarioService;
        }

        [HttpGet("/Capitulo/BuscarCapitulo/{cursoId}")]
        public async Task<ActionResult> BuscarCapitulo(int cursoId)
        {
            IEnumerable<CapituloGet> capituloGet = await _capituloService.BuscaCapitulo(cursoId);
            if (capituloGet.Count() == 0)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhuma capitulo foi encontrado"));
            }

            return Ok(capituloGet);
        }

        [HttpGet("/Capitulo/BuscarCapituloId/{id}")]
        public async Task<ActionResult> BuscarCapituloId(int id)
        {
            CapituloGet capituloGet = await _capituloService.BuscaCapituloPorId(id);
            if (capituloGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhuma capitulo foi encontrado"));
            }

            return Ok(capituloGet);
        }

        [Authorize]
        [HttpPost("/Capitulo/IncluirCapitulo/")]
        public async Task<ActionResult> IncluirCapitulo([FromBody] CapituloPost capituloPost)
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

            CapituloPost capitulo = await _capituloService.AdicionaCapitulo(capituloPost);
            if (capitulo == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Falha ao adicionar capitulo"));
            }

            return Ok(new ResponseModel(HttpStatusCode.OK, "Capitulo criado com Sucesso"));
        }

        [Authorize]
        [HttpPut("/Capitulo/AtualizarCapitulo/")]
        public async Task<ActionResult> AtualizarCapitulo([FromBody] CapituloPut capituloPut)
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

            CapituloGet capituloGet = await _capituloService.BuscaCapituloPorId(capituloPut.Id);
            if (capituloGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Capitulo não encontrada"));
            }

            capituloPut.DataCriacao = capituloGet.DataCriacao;
            capituloPut.CursoId = capituloGet.CursoId;
            capituloPut.Id = capituloGet.Id;

            CapituloPut capituloAlterado = await _capituloService.AtualizaCapitulo(capituloPut);
            if (capituloAlterado == null)
            {
                return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Falha ao atualizar o capitulo"));
            }
            return Ok(new ResponseModel(HttpStatusCode.OK, "Capitulo alterado com sucesso"));
        }


        [Authorize]
        [HttpDelete("/Capitulo/DeletarCapitulo/{id}")]       
        public async Task<ActionResult> DeletarCapitulo(int id)
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

            var capituloDelete = await _capituloService.DeletaCapituloPorId(id);
            if (capituloDelete == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Capitulo não encontrado"));
            }
            return Ok(new ResponseModel(HttpStatusCode.OK, "Capitulo deletado com Sucesso"));
        }
    }
}
