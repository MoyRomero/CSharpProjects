using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace CreatingTXTFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lenguajes = {"JavaScript", "Java","Python","C++","C", "C# (C Sharp)" };
            string texto = $"Hola, mi nombre es Moisés, estoy programando en el lenguaje de programación: {lenguajes[lenguajes.Length-1]}.";

            File.WriteAllText("Informacion.txt", texto);

            string archivo = File.ReadAllText("Informacion.txt");

            Console.WriteLine(archivo);


            //The following methods are available in the File class:

            //AppendAllText() - appends text to the end of the file.

            //Create() - creates a file in the specified location.

            //Delete() - deletes the specified file.

            //Exists() - determines whether the specified file exists.

            //Copy() - copies a file to a new location.

            //Move() - moves a specified file to a new location


    }
    }
}
