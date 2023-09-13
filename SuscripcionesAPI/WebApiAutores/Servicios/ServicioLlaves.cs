using WebApiAutores.Entidades;

namespace WebApiAutores.Servicios
{
    public class ServicioLlaves
    {
        private readonly AplicationDbContext context;

        public ServicioLlaves(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CrearLlave(string usuarioId, TipoLlave tipoLlave)
        {
            var llave = GenerarLlaveString();

            var llaveAPI = new LlaveAPI
            {
                Llave = llave,
                TipoLlave = tipoLlave,
                Activa = true,
                UsuarioId = usuarioId
            };

            context.Add(llaveAPI);
            await context.SaveChangesAsync();
        }

        public string GenerarLlaveString()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
