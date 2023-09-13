

using LINQ_Ejercicios_1;

class ProgramaEjercicios { 

static void Main() {

        //Ejercicio_1();
        //Ejercicio_2();
        //Ejercicio_3();
        //Ejercicio_4();
        //Ejercicio_5();
        //Ejercicio_6();
        Ejercicio_7();

}
    
    static void Ejercicio_1()
    {

        int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var Menores5 = from numero in numeros where numero < 5 select numero;

        Console.WriteLine("Numeros menores a 5: ");
        foreach (int numero in Menores5) Console.WriteLine(numero);

    }

    static void Ejercicio_2() {

        int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var pares = from par in numeros where par % 2 == 0 select par;

        Console.WriteLine("Números pares:");
        foreach(var par in pares) Console.WriteLine(par);

    }

    static void Ejercicio_3()
    {

        string[] frutas = { "cherry", "apple", "blueberry" };

        var des = from fruta in frutas orderby fruta ascending select fruta;
        var asc = from fruta in frutas orderby fruta descending select fruta;

        Console.WriteLine("Orden ASCENDENTE:");
        foreach (var impr in des) Console.WriteLine(impr);
        
        Console.WriteLine("\n");

        Console.WriteLine("Orden DESCENDENTE:");
        foreach(var impr in asc) Console.WriteLine(impr);
    }

    static void Ejercicio_4()
    {
        int[] scores = { 90, 71, 82, 93, 75, 82 };

        Console.Write($"Máxima puntuación: {scores.Max()}");

    }

    static void Ejercicio_5() 
    {
        int[] scores = { 18, 25, 19, 16, 21, 80 };

        var mayor20 = from numeros in scores where numeros > 20 select numeros;

        Console.WriteLine("Puntuaciones mayores a 20: ");
        foreach(var print in mayor20) Console.WriteLine(print);

    }

    static void Ejercicio_6() 
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var men5mult2 = from numeros in numbers where numeros < 5 && numeros%2 == 0 && numeros != 0 select numeros;

        Console.WriteLine("Números menores que 5, y multiplos de 2");

        foreach(var print in men5mult2 ) Console.WriteLine(print);

    }

    static void Ejercicio_7()
    {

        List<Student> Estudiantes = new List<Student> {

            new Student{ First = "Svetlana", Last = "Omelchenko", ID = 111 },
            new Student{ First = "Claire", Last = "O'Donnell", ID = 112 },
            new Student{ First = "Sven", Last = "Mortensen", ID = 113 },
            new Student{ First = "Cesa", Last = "Garcia", ID = 114 },
            new Student{ First = "Debra", Last = "Garcia", ID = 115 }

        };

        var Students = from student in Estudiantes orderby student.Last ascending 
                       select $"Mi nombre es: {student.First} y mi apellido es: {student.Last}";

        Console.WriteLine("Estudiantes ordenados de forma ASCENDENTE:");
        foreach(var student in Students) Console.WriteLine(student);  

    }
}




