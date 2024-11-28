using HermanosK.DAL.Entities;
using HermanosK.Domain.Interfaces;

namespace HermanosK.Domain.Interfaces
{
    public interface IComentarioService
    {
        Task<IEnumerable<Comentario>> GetComentariosAsync();
        Task<Comentario> GetComentarioByIdAsync(Guid id);
        Task<Comentario> CreateComentarioAsync(Comentario comentario);
        Task<Comentario> EditComentarioAsync(Comentario comentario);
        Task<Comentario> DeleteComentarioAsync(Guid id);
    }
}
