﻿namespace PeliculasAPI.Servicios
{
    public interface IAlmacenadorArchivos
    {
        Task<string> GuardarArchivo(byte[] contenido, string extension, string contenedor, string contentType);
        Task BorrarArchivo(string ruta, string contenedor);
        Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string ruta, string contentType);        
    }
}
