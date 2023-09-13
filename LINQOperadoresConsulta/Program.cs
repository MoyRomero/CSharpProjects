using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQOperadoresConsulta
{
    internal class Program
    {
        static void n() {
            Console.WriteLine("\n\n");
        }

        static void Main(string[] args)
        {

            var estudiantes = new[]
            {
                new
                {
                    EstudianteID = 1,
                    Nombre = "Héctor",
                    ApellidoPaterno = "Pérez",
                    Universidad = "Real de Brasil"
                },
                new
                {
                    EstudianteID = 2,
                    Nombre = "Ana",
                    ApellidoPaterno = "Nepomuceno",
                    Universidad = "Oxford"
                },
                new
                {
                    EstudianteID = 3,
                    Nombre = "Pedro",
                    ApellidoPaterno = "Sánchez",
                    Universidad = "Harvard"
                },
                new
                {
                    EstudianteID = 4,
                    Nombre = "José",
                    ApellidoPaterno = "Infante",
                    Universidad = "Harvard"
                },
                new
                {
                    EstudianteID = 5,
                    Nombre = "Regina",
                    ApellidoPaterno = "Bustamante",
                    Universidad = "Oxford"
                },
                new
                {
                    EstudianteID = 6,
                    Nombre = "Rodrigo",
                    ApellidoPaterno = "Jiménez",
                    Universidad = "Brooklyn"
                },
                new
                {
                    EstudianteID = 7,
                    Nombre = "Miguel",
                    ApellidoPaterno = "Hernández",
                    Universidad = "UNAM"
                },
                new
                {
                    EstudianteID = 8,
                    Nombre = "Marilyn",
                    ApellidoPaterno = "Monroe",
                    Universidad = "UNAM"
                },
                new
                {
                    EstudianteID = 9,
                    Nombre = "Leonardo",
                    ApellidoPaterno = "Estrada",
                    Universidad = "Brooklyn"
                },
                new
                {
                    EstudianteID = 10,
                    Nombre = "Ricardo",
                    ApellidoPaterno = "Rojas",
                    Universidad = "Real de Brasil"
                },
            };

            var universidades = new[]
            {
                new
                {
                    Universidad = "Real de Brasil",
                    Ciudad = "Brasilia",
                    Pais = "Brasil"
                },
                new
                {
                    Universidad = "Oxford",
                    Ciudad = "Oxford",
                    Pais = "Reino Unido"
                },
                new
                {
                    Universidad = "Harvard",
                    Ciudad = "Cambridge",
                    Pais = "Estados Unidos"
                },
                new
                {
                    Universidad = "Brooklyn",
                    Ciudad = "Nueva York",
                    Pais = "Estados Unidos"
                },
                new
                {
                    Universidad = "UNAM",
                    Ciudad = "Ciudad de México",
                    Pais = "México"
                },
            };

            // clausula from, seguido de un alias, seguido de una colección, seguido de la clausula select
            var nombresEstudiantes = from nombres in estudiantes select nombres.Nombre;

            Console.WriteLine("Nombres de estudiantes:");
            foreach(var nombres in nombresEstudiantes)
                Console.WriteLine(nombres);

            n();

            //clausula from, seguido de alias, seguido de clausula where, seguido de metodo string para comparar, seguido de clausula select
            var UnisEU = from Unis in universidades where string.Equals(Unis.Pais, "Estados Unidos") select Unis.Universidad;

            Console.WriteLine("Universidades de Estados Unidos:");
            foreach(var Unis in UnisEU)
                Console.Write($"| {Unis} |");

            n();

            var OrdenadosAsc = from nombres in estudiantes orderby nombres.Nombre ascending select nombres.Nombre;
            var OrdenadosDes = from nombres in estudiantes orderby nombres.Nombre descending select nombres.Nombre;
            Console.WriteLine("Estudiantes ordenados de forma Ascendente:");

            foreach(var nombres in OrdenadosAsc)
                Console.WriteLine(nombres);

            n();

            Console.WriteLine("Estudiantes ordenados de forma Descendente:");
            foreach (var nombres in OrdenadosDes)
                Console.WriteLine(nombres);

            n();

            var UgrupoPais = from Unis in universidades group Unis by Unis.Pais;

            Console.WriteLine("Universidades agrupadas por País:");
            foreach (var Unis in UgrupoPais) { 

                Console.Write($"| País: {Unis.Key} |");
                foreach(var nombres in Unis)
                    Console.Write($" {nombres.Universidad} ");
                Console.WriteLine($": {Unis.Count()} ");
            }

            n();
            
            var numeroUnis = (from Unis in universidades select Unis.Universidad).Count();

            Console.WriteLine($"Cantidad TOTAL de Universidades: {numeroUnis}");

            n();

            var numeroUnisEU = (from Unis in universidades where string.Equals(Unis.Pais, "Estados Unidos") select Unis.Universidad).Count();

            Console.WriteLine($"Cantidad de Universidades en EU: {numeroUnisEU}");

            n();

            //Cla join > Alias > Coleccion estudiantes > cla join > Alias > coleccion universidades > campos a comparar > 
            //cla select > creacion de campos mediante tipo anónimo > campos a unir.
            var join = from E in estudiantes join U in universidades on E.Universidad equals U.Universidad 
                       select new { E.Nombre, E.ApellidoPaterno, U.Universidad };

            Console.WriteLine("|  NOMBRE  |  APELLIDO  |  UNIVERSIDAD  |");
            foreach (var Info in join) 
                Console.WriteLine($"| {Info.Nombre} |  {Info.ApellidoPaterno} |  {Info.Universidad} |");
           
            n();
        }
    }
}
