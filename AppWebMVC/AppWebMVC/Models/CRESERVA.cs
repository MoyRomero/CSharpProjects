using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWebMVC.Models
{
    public class CRESERVA
    {
        public int IDViaje { get; set; }
        public string NombrePersona { get; set; }
        public string NombreUsuario { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int IDBus { get; set; }
        public string PlacaBus { get; set; }
        public string DescripcionBus { get; set; }
        public DateTime FechaViaje { get; set; }
        public DateTime FechaCompra { get; set; }
        public string NombreFoto { get; set; }
        public byte[] Foto { get; set; }
        public int IDLugarOrigen { get; set; }
        public string LugarOrigen { get; set; }
        public int IDLugarDestino { get; set; }
        public string LugarDestino { get; set; }
        public int AsientosDisponibles { get; set; }
        public int AsientosReservados { get; set; }
        public int TotalAsientos { get; set; }

    }
}