using Microsoft.EntityFrameworkCore;
using HermanosK.Domain.Interfaces;
using HermanosK.DAL.Entities;
using HermanosK.DAL;

namespace HermanosK.Domain.Services
{
    public class ComentarioService:IComentarioService
    {
        private readonly DataBaseContext _context;

        public ComentarioService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comentario>> GetComentariosAsync()
        {
            return await _context.Comentarios.ToListAsync();
        }

        public async Task<Comentario> GetComentarioByIdAsync(Guid id)
        {
            return await _context.Comentarios.FindAsync(id);
        }

        public async Task<Comentario> CreateComentarioAsync(Comentario comentario)
        {
            comentario.Id = Guid.NewGuid();
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
            return comentario;
        }

        public async Task<Comentario> EditComentarioAsync(Comentario comentario)
        {
            var existing = await _context.Comentarios.FindAsync(comentario.Id);
            if (existing == null) return null;

            existing.Texto = comentario.Texto;
            existing.Calificacion = comentario.Calificacion;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Comentario> DeleteComentarioAsync(Guid id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null) return null;

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return comentario;
        }
    }
}
