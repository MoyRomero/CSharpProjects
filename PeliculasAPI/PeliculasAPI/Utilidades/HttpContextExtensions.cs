using Microsoft.EntityFrameworkCore;

namespace PeliculasAPI.Utilidades
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacionEnCabecera<T>(this HttpContext httpContext, IQueryable<T> queryable,
            int RecordsPorPagina, int Pagina)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            double cantidad = await queryable.CountAsync();
            double cantidadPaginas = Math.Ceiling(cantidad/ RecordsPorPagina);
            httpContext.Response.Headers.Add("cantidadTotalRegistros", cantidad.ToString());
            httpContext.Response.Headers.Add("cantidadPaginas", cantidadPaginas.ToString());
            httpContext.Response.Headers.Add("paginaActual", Pagina.ToString());
        }
    }
}
