using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(){

        bool ejecutarDeNuevo = true;
        string respuesta ;

        do{
            TamanioVentana();

            Console.WriteLine("¿Desea salir del programa? Sí: 1 - No: 0");

            respuesta = Console.ReadLine();


            if (respuesta == "1"){
                ejecutarDeNuevo=false;
              }
            
            LimpiarVentana();

            Console.ReadLine();

        }while(ejecutarDeNuevo == true);

        Console.WriteLine("Ha salido del programa :) presiona cualquier tecla para cerrar.");

    }

    static void TamanioVentana(){

        string width;
        string height;

        Console.WriteLine("Determina un tamaño de la ventana");

        Console.WriteLine("Introduce un alto:");

        width = Convert.ToString(Console.ReadLine());
        Console.WriteLine("Introduce un ancho:");
        height = Convert.ToString(Console.ReadLine());

        Console.SetWindowSize(Convert.ToInt32(width), Convert.ToInt32(height));

        Console.WriteLine($"El tamaño de la ventana ahora es {width} x {height}");


    }

    static void LimpiarVentana(){
        bool limpiar = false;
        string respuesta;

        while (limpiar == false){

            Console.WriteLine("¿Desea limpiar la ventana? Escribir: si/no.");
            respuesta = Console.ReadLine();

            if (respuesta == "si" || respuesta == "Si" || respuesta == "sI" || respuesta == "SI"){
                limpiar = true;

                Console.Clear();
               
            }

            else if (respuesta == "no" || respuesta == "No" || respuesta == "nO" || respuesta == "NO") break;

            else Console.WriteLine("Debe escribir si / no (sin acentos).");
        }

        Console.WriteLine("Presiona cualquier tecla para continuar");
    }

}