using System.ComponentModel.DataAnnotations;

namespace HermanosK.DAL.Entities
{
    public class Comentario
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public int Calificacion { get; set; } // Por ejemplo: de 1 a 5 estrellas
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
