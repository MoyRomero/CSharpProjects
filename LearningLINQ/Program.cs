using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningLINQ
{
    internal class Program
    {
        static void n()
        {
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

            //Utilizando Select para seleccionar los nombres de los Alumnos, con sus respectivos apellidos parternos.
            var EstudiantesDatos = estudiantes.Select(x => new { x.Nombre, x.ApellidoPaterno });

            //Filtrando con la clausula Where();, previo a un Select de las Universidades.
            var UniversidadesEU = universidades.Where(x => x.Pais == "Estados Unidos").Select(x => x.Universidad);

            //Ordenando con la clausula OrderBy(); (Des o Asc), previo a un Select de las Universidades.
            var uDes = universidades.OrderByDescending(x => x.Universidad);

            //uDes ordenado por Universidad de forma Desc, para posteriormente ordenar por Pais y Seleccionar las Universidades.
            var upDes = uDes.OrderByDescending(x => x.Pais).ThenBy(x => x.Universidad).Select(x => new { x.Universidad, x.Pais });

            //Agrupamiento de las universidades con clausula GroupBy();
            var uGrByP = universidades.GroupBy(x => x.Pais);

            //Conteo de Paises existentes
            int numeroPaises = universidades.Select(x => x.Pais).Distinct().Count();// 4 paises


            //Union de "tablas" con clausula .Join(); 
            var join = estudiantes.Select(x => new { x.Nombre, x.ApellidoPaterno, x.Universidad })

            .Join(universidades, x => x.Universidad, u => u.Universidad, (x, u) => new { x.Nombre, x.ApellidoPaterno, u.Pais });


            //Impresión de los resultados de las Clausulas            

            Console.WriteLine("Resultado de unión de tablas:");
            Console.WriteLine("NOMBRE   -   APELLIDO   -   PAÍS");

            foreach (var info in join)
                Console.WriteLine($"{info.Nombre}     {info.ApellidoPaterno}        {info.Pais}");

            n();

        }        

    }
}
