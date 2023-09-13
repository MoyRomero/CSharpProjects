using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GetTypeAndArrays
{
    internal class Program
    {       

        static void Main(){

            //ComprobarTipo();

            //CopiaDeArreglos();

            //ArregloBidimensional();

            //int resultado = SumaDeNumeros(1,1,1,1,1);

            //MaxMin();

            //checkPassword();

            //CharString();

            //FindingLetter();

            //FinalRound();

            SortingArray();


            double num1 = Convert.ToDouble(Console.ReadLine());
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("1");

            Avg avg = new Avg(num1, num2);

            Console.WriteLine(avg.GetAvg());

            Console.WriteLine("2");


        }

        private static void SortingArray()
        {

            int count = 5;

            int[] numbers = new int[count];
            
            for (int i = 0; i < count; i++)
            {

                numbers[i] = Convert.ToInt32(Console.ReadLine());

            }

            Array.Sort(numbers);
            Console.WriteLine(numbers);

        }

        private static void FinalRound()
        {
            string[] finalists = { "James Van", "John Smith", "Leyla Brown", "Tom Homerton", "Bob Douglas" };

            int winner = 2;

            //this should show the winner and "Game Over"
            FinalRound finalRound = new FinalRound(finalists, winner);

        }

        private static void FindingLetter(){

            string[] words = {
                "home",
                "programming",
                "victory",
                "C#",
                "football",
                "sport",
                "book",
                "learn",
                "dream",
                "fun"
            };

            string letter = "z";

            int contador = 0;

            foreach (var word in words)
            {

                if (word.Contains(letter))
                {
                    contador++;

                    Console.WriteLine(word);                    
                    
                }                
            }

            if (contador == 0)
            {
                Console.WriteLine("No Match");
            }

        }

        private static void CharString()
        {
            //Funcion para insertar en un Char, la última cadena de una string

            string s = "Hello";
            int x;
            x = s.IndexOf("o");

            Console.WriteLine(9%5);
        }

        private static int SumaDeNumeros(params int[] numeros)
        {
            int suma = 0;

            foreach (int numero in numeros)
            {
                suma += numero;
            }

            Console.WriteLine($"El resultado de la suma es {suma}");

            return suma;

        }

        private static void ComprobarTipo()
        {
            int[] numeros    = { 1, 2, 3, 4, 5, 6 };
            string[] nombres = {"Perla","Bob Esponja","Calamardo","Patricio","Don Cangrejo","Arenita" };

            var desconocido = new[] { $"{numeros}", $"{nombres}" };

            Console.WriteLine($"El tipo de dato de numeros, es: {desconocido[0]}");
            Console.WriteLine($"El tipo de dato de nombres, es: {desconocido[1]}");
            Console.WriteLine(desconocido.GetType());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Impresion de valores de ambos arreglos");

            for ( int i = 0; i < numeros.Length; i++)
            {

                Console.WriteLine($"El índice {i} contiene el valor {numeros[i]}");

                Console.WriteLine($"El índice {i} contiene el nombre {nombres[i]}");

            }
        }

        private static void CopiaDeArreglos()
        {
            //Copia de Arreglos 
            int[] arregloOriginal = { 1, 2, 3, 4, 5 };

            int[] arregloCopia = new int[arregloOriginal.Length];


            Array.Copy(arregloOriginal, arregloCopia, arregloOriginal.Length);

            Console.WriteLine("Arreglo Original");
            foreach (int i in arregloOriginal)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Arreglo Copia");
            foreach (int i in arregloCopia)
            {
                Console.WriteLine(i);
            }
        }
        
        private static void ArregloBidimensional()
        {
            string[,] arreglo = new string[2,2];

            Console.WriteLine("Se ha creado un arreglo bidimensional.");
            

            for( int i = 0;i <= arreglo.Length/2; i++) {

                if (i == arreglo.Length/2)
                {
                    for (int j = 0; j < arreglo.Length/2; j++)
                    {
                        Console.WriteLine($" Luchador: {arreglo[0,j]}, Aliado: {arreglo[1,j]}.");
                    }

                    break;
                }

                Console.WriteLine($"Ingresa Personaje {i}:");
                arreglo[0, i] = Console.ReadLine();

                Console.WriteLine($"Ingresa el Compa del personaje {arreglo[0, i]}.");
                arreglo[1, i] = Console.ReadLine();
                
                
            }
            
        }

        private static void MaxMin()
        {            
        
                //your code goes here
                int[] array = new int[5];

                for (int i = 0; i <= 4; i++)
                {

                    array[i] = Convert.ToInt32(Console.ReadLine());

                }

                Console.WriteLine(array.Max() + array.Min());

            }
        
        private static void checkPassword()
        {
            string password = "hola";
            char[] notAllowedSymbols = { '!', '#', '$', '%', '&', '(', ')', '*', ',', '+', '-' };

            //your code goes here

           foreach(char c in notAllowedSymbols)
            {            

                if (password.Contains(c))
                {
                    Console.WriteLine("Invalid Password");
                    break;
                }
                else
                {
                    Console.WriteLine("Valid Password");
                }

            }

        }
    }

    class FinalRound
    {           
       
            public FinalRound(string[] finalists, int winner)
            {
                //complete the constructor
                Console.WriteLine("Winner is " + finalists[winner]);
            }

            //create destructor => "Game Over"

            ~FinalRound()
            {
                Console.WriteLine("Game Over");
            }

    }

        class Avg
        {
            double num1;
            double num2;

            //create the constructor
            public Avg(double num_1, double num_2)
            {

                Console.WriteLine("3");
                this.num1 = num_1;
                this.num2 = num_2;
            }

            public double GetAvg()
            {
                return (num1 + num2) / 2;
            }
        }


}

