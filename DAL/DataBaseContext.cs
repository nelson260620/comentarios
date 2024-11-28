using HermanosK.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HermanosK.DAL
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración inicial
            modelBuilder.Entity<Comentario>().HasKey(c => c.Id);
            modelBuilder.Entity<Comentario>().Property(c => c.Calificacion).IsRequired();
        }

    }
}
