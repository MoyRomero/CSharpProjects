using AppWebMVC.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AppWebMVC.Filters;


namespace AppWebMVC.Controllers
{
    [Access]
    public class MarcaController : Controller
    {
        public FileResult GenerarExcelByte()
        {
            byte[] Buffer;

            using(MemoryStream ms = new MemoryStream())
            {
                ExcelPackage EP = new ExcelPackage();//Creacion del documento

                EP.Workbook.Worksheets.Add("Reporte");//Creacion de 1 hoja

                ExcelWorksheet EW_1 = EP.Workbook.Worksheets[0];//Referencia a la primera hoja

                //Introduciendo valores a las celdas
                EW_1.Cells[1, 1].Value = "ID Marca";
                EW_1.Cells[1, 2].Value = "NOMBRE";
                EW_1.Cells[1, 3].Value = "DESCRIPCIÓN";

                //Asignando ancho a las Columnas
                EW_1.Column(1).Width = 20;
                EW_1.Column(2).Width = 40;
                EW_1.Column(3).Width = 90;

                //Determinando colores de Celdas
                using(var range = EW_1.Cells[1, 1, 1, 3])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                }

                List<CMARCA> ListaMarcas = (List<CMARCA>) Session["ListaTablaMarcas"];

                for(int i = 0; i < ListaMarcas.Count; i++)
                {
                    EW_1.Cells[i+2, 1].Value = ListaMarcas[i].IDMarca;
                    EW_1.Cells[i+2, 2].Value = ListaMarcas[i].NOMBRE;
                    EW_1.Cells[i+2, 3].Value = ListaMarcas[i].DescripMarca;
                }

                EP.SaveAs(ms);
                Buffer = ms.ToArray();
            }

            return File(Buffer,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
        public FileResult GenerarPDF()
        {            
            Document doc = new Document(); //Creacion del documento
            
            byte[] Buffer;//almacenamiento en memoria

            using (MemoryStream ms = new MemoryStream())
            {

                PdfWriter.GetInstance(doc,ms);

                doc.Open();

                Paragraph Titulo = new Paragraph("Lista de Marcas");//Creacion del titulo
                Titulo.Alignment = Element.ALIGN_CENTER;//Alineacion del título
                doc.Add(Titulo);//Agregando un elemento al archivo pdf

                Paragraph BR = new Paragraph(" ");
                doc.Add(BR);

                PdfPTable Tabla = new PdfPTable(3); //Creacion de la tabla
                float[] AnchosColumnas = new float[3] { 30, 40, 80 }; //Definicion del ancho de las columnas
                Tabla.SetWidths(AnchosColumnas); //Asignacion del ancho de las columnas

                PdfPCell Celda_1 = new PdfPCell(new Phrase("ID MARCA"));
                Celda_1.BackgroundColor = new BaseColor(200, 200, 200);
                Celda_1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                Tabla.AddCell(Celda_1);

                PdfPCell Celda_2 = new PdfPCell(new Phrase("NOMBRE"));
                Celda_2.BackgroundColor = new BaseColor(220, 220, 220);
                Celda_2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                Tabla.AddCell(Celda_2);

                PdfPCell Celda_3 = new PdfPCell(new Phrase("DESCRIPCIÓN"));
                Celda_3.BackgroundColor = new BaseColor(250, 250, 250);
                Celda_3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                Tabla.AddCell(Celda_3);
                

                List<CMARCA> ListaMarcas = (List<CMARCA>) Session["ListaTablaMarcas"];

                for(int i = 0; i < ListaMarcas.Count; i++)
                {

                    PdfPCell CeldaID = new PdfPCell(new Phrase(ListaMarcas[i].IDMarca.ToString()));
                    CeldaID.BackgroundColor = new BaseColor(190, 250, 190);
                    CeldaID.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    Tabla.AddCell(CeldaID);

                    PdfPCell CeldaNombre = new PdfPCell(new Phrase(ListaMarcas[i].NOMBRE));
                    CeldaNombre.BackgroundColor = new BaseColor(190, 250, 190);
                    CeldaNombre.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    Tabla.AddCell(CeldaNombre);

                    PdfPCell CeldaDescripcion = new PdfPCell(new Phrase(ListaMarcas[i].DescripMarca));
                    CeldaDescripcion.BackgroundColor = new BaseColor(190, 250, 190);
                    CeldaDescripcion.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    Tabla.AddCell(CeldaDescripcion);
                }

                doc.Add(Tabla);

                doc.Close();

                Buffer = ms.ToArray();
            }

            return File(Buffer,"application/pdf");
        }
        // GET: Marca
        public ActionResult Index(CMARCA oMarca)
        {
            List<CMARCA> ListaMarca = null;

            using (var BD = new BDPasajeEntities()) 
            {
               if(oMarca.NOMBRE == null)
                {
                    ListaMarca = (from marca in BD.Marca
                                  where marca.BHABILITADO == 1
                                  select new CMARCA
                                  {
                                      IDMarca = marca.IIDMARCA,
                                      NOMBRE = marca.NOMBRE,
                                      DescripMarca = marca.DESCRIPCION
                                  }).ToList();
                }
                else
                {
                    ListaMarca = (from n in BD.Marca
                                  where n.BHABILITADO == 1 &&
                                  n.NOMBRE.Contains(oMarca.NOMBRE)
                                  select new CMARCA
                                  {
                                      IDMarca = n.IIDMARCA,
                                      NOMBRE = n.NOMBRE,
                                      DescripMarca = n.DESCRIPCION
                                  }).ToList();                    
                }
            }

            Session["ListaTablaMarcas"] = ListaMarca;

            return View(ListaMarca);
        }
        public ActionResult Agregar()
        {
            return View();
        }
        public ActionResult Editar(int id)
        {
            CMARCA Cmarca = new CMARCA();    

            using (var BD = new BDPasajeEntities())
            {
                Marca oMarca = (from ma in BD.Marca where ma.IIDMARCA.Equals(id) select ma).First();

                Cmarca.IDMarca = oMarca.IIDMARCA;
                Cmarca.NOMBRE = oMarca.NOMBRE;
                Cmarca.DescripMarca = oMarca.DESCRIPCION;                
            }
                return View(Cmarca);
        }
        public ActionResult Eliminar (int idElemento)
        {
            using(var BD = new BDPasajeEntities())
            {
                Marca mar = (from m in BD.Marca where m.IIDMARCA.Equals(idElemento) select m).First();

                mar.BHABILITADO = 0;

                BD.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Agregar(CMARCA informacion)
        {
            int repetido = 0;

            using (var BD = new BDPasajeEntities())
            {
                repetido = (from m in BD.Marca where m.NOMBRE.Equals(informacion.NOMBRE) select m).Count(); 
            }

            if (!ModelState.IsValid || repetido > 0)
            {
                if (repetido > 0)
                {
                    informacion.MensajeError = $"El nombre de la MARCA: {informacion.NOMBRE}, ya existe en la base de datos.";
                }

                return View(informacion);
            }
            else
            {
                using(var BD = new BDPasajeEntities())
                {
                    Marca marca = new Marca();

                    marca.NOMBRE = informacion.NOMBRE;
                    marca.DESCRIPCION = informacion.DescripMarca;
                    marca.BHABILITADO = 1;
                    
                    BD.Marca.Add(marca);
                    BD.SaveChanges();
                }
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(CMARCA info)
        {       
            int id = info.IDMarca;
            int repetido = 0;

            using (var BD = new BDPasajeEntities())
            {
                repetido = (from m in BD.Marca where m.NOMBRE.Equals(info.NOMBRE) && !m.IIDMARCA.Equals(id) select m).Count();
            }

            if (!ModelState.IsValid || repetido > 0)
            {
                if (repetido > 0)
                {
                    info.MensajeError = $"El nombre de la MARCA: {info.NOMBRE}, ya existe en la base de datos.";
                }
                return View(info);
            }

            using (var BD = new BDPasajeEntities())
            {
                Marca oMarca = (from ma in BD.Marca where ma.IIDMARCA.Equals(id) select ma).First();

                oMarca.NOMBRE = info.NOMBRE;
                oMarca.DESCRIPCION = info.DescripMarca;

                BD.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}