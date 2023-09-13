using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Ejercicios_2
{
    class Ejercicios_2 { 

        static void Main(string[] args)
        {
            //Ejercicio_1();
            //Ejercicio_2();
            Ejercicio_3();
        }

        static void Ejercicio_1()
        {

            List<Curso> Cursos = new List<Curso>
            {

                new Curso { idCurso = 1, nombreCurso = "MATEMÁTICAS"},
                new Curso { idCurso = 2, nombreCurso = "BIOLOGÍA"},
                new Curso { idCurso = 3, nombreCurso = "QUÍMICA"},
                new Curso { idCurso = 4, nombreCurso = "ELECTRÓNICA"},
                new Curso { idCurso = 5, nombreCurso = "PROGRAMACIÓN"},
                new Curso { idCurso = 6, nombreCurso = "ÁLGEBRA"},
                new Curso { idCurso = 7, nombreCurso = "CÁLCULO"}

            };

            List<Profesor> Profesores = new List<Profesor>
            {
                new Profesor { idProfesor = 1, idCurso = 4, Edad = 30, nombreProfesor = "Raúl Ramírez", genero= "Masculino"},
                new Profesor { idProfesor = 2, idCurso = 7, Edad = 45, nombreProfesor = "Dímas Díaz", genero= "Masculino"},
                new Profesor { idProfesor = 3, idCurso = 3, Edad = 34, nombreProfesor = "Alejandra Morales", genero= "Femenino"},
                new Profesor { idProfesor = 4, idCurso = 6, Edad = 31, nombreProfesor = "José Obregón", genero= "Masculino"},
                new Profesor { idProfesor = 5, idCurso = 2, Edad = 37, nombreProfesor = "Juan Ramírez", genero= "Masculino"},
                new Profesor { idProfesor = 6, idCurso = 5, Edad = 37, nombreProfesor = "Héctor Rosendo", genero= "Masculino"},
                new Profesor { idProfesor = 7, idCurso = 1, Edad = 40, nombreProfesor = "Elvia Gómez", genero= "Femenino"}
            };

            var infoCurso = from curso in Cursos
                            join profe in Profesores
                            on curso.idCurso equals profe.idCurso
                            select new { curso.nombreCurso, profe.nombreProfesor, profe.genero };

            foreach (var info in infoCurso) 
            { 
                if(info.genero == "Femenino")
                {
                    Console.WriteLine($"El curso: {info.nombreCurso}, es impartido por la profesora: {info.nombreProfesor}.");
                }
                else if(info.genero == "Masculino")
                { 
                    Console.WriteLine($"El curso: {info.nombreCurso}, es impartido por el profesor: {info.nombreProfesor}.");
                }

            }
        }

        static void Ejercicio_2()
        {
            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var pares = numeros.Where(x => x%2 == 0 && x != 0).Select(x => x);

            Console.WriteLine("Números pares:");
            foreach (int numero in pares) Console.WriteLine(numero);
        }

        static void Ejercicio_3()
        {
            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var mayores5 = numeros.Where(x => x > 5).Select(x => x);

            Console.WriteLine("Números mayores a 5:");
            foreach(int numero in mayores5) Console.WriteLine(numero);
        }
    }
}
