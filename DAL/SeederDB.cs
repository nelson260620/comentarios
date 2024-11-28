using HermanosK.DAL.Entities;

namespace HermanosK.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        // Método SeederAsync para pre-poblar la base de datos
        public async Task SeederAsync()
        {
            // Asegura que la base de datos está creada antes de intentar insertar datos.
            await _context.Database.EnsureCreatedAsync();

            // Métodos para poblar las tablas necesarias en la base de datos.
            await PopulaterCommentsAsync();

            // Guardar cambios en la base de datos.
            await _context.SaveChangesAsync();
        }

        // Método de ejemplo para poblar la tabla de comentarios.
        private async Task PopulaterCommentsAsync()
        {
            // Evitar insertar datos duplicados.
            if (!_context.Comentarios.Any())
            {
                _context.Comentarios.AddRange(
                    new Comentario { Id = Guid.NewGuid(), Texto = "Excelente servicio", Fecha = DateTime.UtcNow },
                    new Comentario { Id = Guid.NewGuid(), Texto = "Muy buen producto", Fecha = DateTime.UtcNow },
                    new Comentario { Id = Guid.NewGuid(), Texto = "Atención rápida", Fecha = DateTime.UtcNow }
                );

                await Task.CompletedTask;
            }
        }
    }
}
