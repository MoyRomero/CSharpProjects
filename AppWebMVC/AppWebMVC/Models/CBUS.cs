using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppWebMVC
{
    public class CBUS
    {
        [Display(Name = "ID")]
        public int IDBus { get; set; }

        [Display(Name = "SUCURSAL")]
        public string Sucursal { get; set; }
        [Required]
        public int IDSucursal { get; set; }

        [Display(Name = "TIPO BUS")]
        public string TipoBus { get; set; }
        [Required]
        public int IDTipoBus { get; set; }

        [Display(Name = "PLACA")]
        [StringLength(100, ErrorMessage = "El máximo de caractéres para el campo, es de: 100.")]
        [Required]
        public string Placa { get; set; }

        [Display(Name = "FECHA COMPRA")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaCompra { get; set; }

        [Display(Name = "MODELO")]
        public string Modelo { get; set; }
        [Required]
        public int IDModelo { get; set; }

        [Display(Name = "FILAS")]
        [Required]
        public int NumeroFilas { get; set; }

        [Display(Name = "COLUMNAS")]
        [Required]
        public int NumeroColumnas { get; set; }

        [Display(Name = "DESCRIPCION")]
        public string Descripcion { get; set; }

        [Display(Name = "OBSERVACIONES")]
        public string Observacion { get; set;}

        [Display(Name = "MARCA")]
        public string Marca { get; set; }
        [Required]
        public int IDMarca { get; set; }

        public int BHabilitado { get; set; }

        public string MensajeErrorPlaca { get; set; }
    }
}