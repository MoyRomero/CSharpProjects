using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClasesPOO
{
    class Program
    {
        static void Main()
        {
            IniciarPrograma();
        }     
        
        static void IniciarPrograma()
        {
            bool seguir = true;
            do
            {
                Console.WriteLine("¿Desea crear una figura? 1:sí / 2:no.");

                string crearFigura = Console.ReadLine();

                if(Convert.ToInt32(crearFigura) == 2)
                {
                    seguir = false;
                    Console.WriteLine("Saliendo del programa.");

                    continue;
                }

                Console.WriteLine("Qué figura desea crear? OPCIONES: 1: Rectángulo / 2: Círculo.");

                string decision = Console.ReadLine();

                switch (Convert.ToInt32(decision))
                {

                    case 1:

                        CrearRectangulo();

                        break;

                    case 2:

                        CrearCirculo();

                        break;

                    default:

                        Console.WriteLine("No ha seleccionado una respuesta válida.");
                        Console.WriteLine("Regresando al menú principal.");

                        break;
                }


            }while (seguir == true);
        }

        static void CrearRectangulo()
        {

            Console.WriteLine("Escribe color del Rectángulo."); string color = Console.ReadLine();

            Console.WriteLine("Determina una altura."); string height = Console.ReadLine();

            Console.WriteLine("Determina una anchura"); string width = Console.ReadLine();

            Rectangulo rectangulo = new Rectangulo(color, Convert.ToDouble(height), Convert.ToDouble(width));

            Console.WriteLine($"Hola, el color de tu rectangulo es:{rectangulo.color}, tiene una altura de: {rectangulo.altura}, una anchura de {rectangulo.ancho}, su Área es: {rectangulo.AreaRectangulo()} y su perímetro es {rectangulo.PerimRectangulo()}.");

        }

        static void CrearCirculo()
        {
            Console.WriteLine("Introduce el radio de tu circulo."); string radio = Console.ReadLine();

            Circulo circulo = new Circulo(Convert.ToInt32(radio));

            Console.WriteLine($"La circunferencia de tu circulo es: {circulo.CalcularCircunferencia()}");
        }
    }
}
