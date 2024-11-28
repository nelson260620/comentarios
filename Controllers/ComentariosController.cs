using HermanosK.DAL.Entities;

using HermanosK.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HermanosK.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly IComentarioService _comentarioService;

        public ComentariosController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetComentariosAsync()
        {
            var comentarios = await _comentarioService.GetComentariosAsync();
            if (comentarios == null || !comentarios.Any()) return NotFound();
            return Ok(comentarios);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Comentario>> GetComentarioByIdAsync(Guid id)
        {
            var comentario = await _comentarioService.GetComentarioByIdAsync(id);
            if (comentario == null) return NotFound();
            return Ok(comentario);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Comentario>> CreateComentarioAsync(Comentario comentario)
        {
            var newComentario = await _comentarioService.CreateComentarioAsync(comentario);
            return Ok(newComentario);
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<Comentario>> EditComentarioAsync(Comentario comentario)
        {
            var updatedComentario = await _comentarioService.EditComentarioAsync(comentario);
            if (updatedComentario == null) return NotFound();
            return Ok(updatedComentario);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteComentarioAsync(Guid id)
        {
            var deletedComentario = await _comentarioService.DeleteComentarioAsync(id);
            if (deletedComentario == null) return NotFound();
            return Ok("Comentario eliminado satisfactoriamente");
        }
    }
}
