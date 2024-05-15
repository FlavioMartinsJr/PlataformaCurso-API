using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaCursos.API.Models;
using PlataformaCursos.Application.DTOs.Capitulo;
using PlataformaCursos.Application.DTOs.Matricula;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Application.Services;
using PlataformaCursos.Infrastructure.IOC;
using System.Net;

namespace PlataformaCursos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MatriculaController : Controller
    {
        private readonly IMatriculaService _matriculaService;
        private readonly IUsuarioService _usuarioService;
        public MatriculaController(IMatriculaService matriculaService, IUsuarioService usuarioService)
        {
            _matriculaService = matriculaService;
            _usuarioService = usuarioService;
        }

        [HttpGet("/Matricula/BuscarMatricula/{usuarioId}")]
        public async Task<ActionResult> BuscarMatricula(int usuarioId)
        {
            var userId = User.GetId();
            var user = await _usuarioService.BuscaUsuarioPorId(userId);
            
            if (usuarioId == 0)
            {
                usuarioId = userId;
            }

            if (user == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Usuario não encontrado"));
            }

            if(!user.IsAdmin && user.Id != usuarioId)
            {
                return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Você não tem permissão para ver outras matriculas"));
            }

            IEnumerable<MatriculaGet> matriculaGet = await _matriculaService.BuscaMatricula(usuarioId);
            if (matriculaGet.Count() == 0)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Nenhuma Matricula foi encontrado"));
            }

            return Ok(matriculaGet);
        }

        [HttpGet("/Matricula/BuscarMatriculaId/{id}")]
        public async Task<ActionResult> BuscarMatriculaId(int id)
        {
            var userId = User.GetId();
            var user = await _usuarioService.BuscaUsuarioPorId(userId);
           

            MatriculaGet matriculaGet = await _matriculaService.BuscaMatriculaPorId(id);
            

            if (user == null || matriculaGet == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Matricula não encontrada"));
            }

            if (!user.IsAdmin && user.Id != matriculaGet.UsuarioId)
            {
                return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Você não tem permissão para ver outras matriculas"));
            }
            

            return Ok(matriculaGet);
        }

        [HttpPost("/Matricula/IncluirMatricula/")]
        public async Task<ActionResult> IncluirMatricula([FromBody] MatriculaPost matriculaPost)
        {
            var userId = User.GetId();
            var userAuth = await _usuarioService.BuscaUsuarioPorId(userId);

            if (userAuth == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Usuario invalido"));
            }

            if (!userAuth.IsAdmin)
            {
                return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Usuario não tem permissão"));
            }

            var matriculaDelete = await _matriculaService.AdicionaMatricula(matriculaPost);
            if (matriculaDelete == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Matricula não encontrado"));
            }
            return Ok(new ResponseModel(HttpStatusCode.OK, "Matricula incluida com Sucesso"));
        }

        [HttpDelete("/Matricula/DeletarMatricula/{id}")]
        public async Task<ActionResult> DeletarMatricula(int id)
        {
            var userId = User.GetId();
            var userAuth = await _usuarioService.BuscaUsuarioPorId(userId);

            if (userAuth == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Usuario invalido"));
            }

            if (!userAuth.IsAdmin)
            {
                return Unauthorized(new ResponseModel(HttpStatusCode.Unauthorized, "Usuario não tem permissão"));
            }

            MatriculaPut matriculaDelete = await _matriculaService.DeletaMatriculaPorId(id);
            if (matriculaDelete == null)
            {
                return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Matricula não encontrado"));
            }
            return Ok(new ResponseModel(HttpStatusCode.OK, "Matricula deletado com Sucesso"));
        }
    }
}
