using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNetAPI.Context;
using MyNetAPI.Models;
using MyNetAPI.Models.DTO;
using MyNetAPI.Services;
using System.Collections.Generic;
using System.Text.Json;

namespace MyNetAPI.Controllers
{

    [ApiController]
    [Route("Usuarios")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly MyApiContext _context;
        private UsuarioServices _usuarioServices;

        public UsuarioController(MyApiContext context,UsuarioServices usuarioServices){
            _context = context;
            _usuarioServices = usuarioServices;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult<UsuarioExibicaoDTO> CriarUsuario([FromBody] UsuarioCriacaoDTO usuarioDTO)
        {
            var usuario = _usuarioServices.CriarUsuario(usuarioDTO);
            return CreatedAtAction(nameof(CriarUsuario), new { id = usuario.Id }, new UsuarioExibicaoDTO(usuario));
        }

        [HttpGet("All")]
        [Authorize(Roles ="Admin,Visualizador")]
        public ActionResult<List<UsuarioExibicaoDTO>> ListarTodos(){
            var usuarios = _usuarioServices.ListarUsuarios();   
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [Authorize(Roles ="Admin,Visualizador")]
        public ActionResult ObterPorId(int id){
            var usuario = _usuarioServices.ObterPorId(id);     
            if(usuario == null) return NotFound();
            return Ok(new UsuarioExibicaoDTO(usuario));  
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Admin")]
        public ActionResult Atualizar(int id, UsuarioEdicaoDTO edicaoDTO){
            var usuarioAtualizado = _usuarioServices.AtualizarUsuario(id,edicaoDTO);
            if(usuarioAtualizado == null) return NotFound();
            return Ok(new UsuarioExibicaoDTO(usuarioAtualizado));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public ActionResult Deletar(int id){
            var delecaoBemSucedida = _usuarioServices.DesativarUsuario(id);
            if(!delecaoBemSucedida) return NotFound();
            return NoContent();
        }
    }
}