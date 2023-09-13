using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsultaDeLenguajeIntegrado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NotaAprobatoria_1();
            //NumerosPares_2();
            //CustomersFiltradoAcapulco_3();
            //EmpleadosSueldo_4();
            //AlumnosCalificaciones_5();
            //JoiningCollections_6();
            //JoiningCollections2_7();
            //JoiningCollections3_8();
            //ExpresionesLambda_9();
            //ExpresionesLambda2_10();
            //ExpresionesLambda3_11();
            //ExpresionesLambda4_12();
            ExpresionesLambda5_13();
        }

        static void ExpresionesLambda5_13()
        {
            List<Empleados> empleados = new List<Empleados>
            {
                new Empleados {nombre = "María", apellido = "Riquelme", genero = "Femenino", sueldo = 1800},
                new Empleados {nombre = "Rogelio", apellido = "Santoyo", genero = "Masculino", sueldo = 2300},
                new Empleados {nombre = "Alondra", apellido = "Palacios", genero = "Femenino", sueldo = 1300},
                new Empleados {nombre = "Sebastián", apellido = "Barrientos", genero = "Masculino", sueldo = 4000},
                new Empleados {nombre = "Rolando", apellido = "Mota", genero = "Masculino", sueldo = 2000},
                new Empleados {nombre = "Benito", apellido = "Camelo", genero = "Masculino", sueldo = 1900},
                new Empleados {nombre = "Juan", apellido = "Gabriel", genero = "Masculino", sueldo = 3000},
                new Empleados {nombre = "Alejandra", apellido = "Marquez", genero = "Femenino", sueldo = 1500}
            };

            var sueldoAnual = empleados.Where(x => x.genero == "Masculino" && x.sueldo > 2000)
                .Select(e => new { nombre = new { e.nombre, e.apellido }, sueldoAnual = e.sueldo * 12 })
                .OrderByDescending(x => x.sueldoAnual);

            foreach (var datos in sueldoAnual) Console.WriteLine($"El empleado: {datos.nombre.nombre} {datos.nombre.apellido} tiene un sueldo anual de: ${datos.sueldoAnual}");


        }

        static void ExpresionesLambda4_12()
        {

            List<ModalidadContrato> listaModalidad = new List<ModalidadContrato> {

                new ModalidadContrato{ idModalidad = 1, nombreModalidad = "Indefinido" },
                new ModalidadContrato{ idModalidad = 2, nombreModalidad = "Temporal" }

            };

            List<Empleadoas> listaEmpleados = new List<Empleadoas> {

                new Empleadoas{ idEmpleado = 1, nombre = "Pancho", idModalidad = 2},
                new Empleadoas{ idEmpleado = 2, nombre = "Juancha", idModalidad = 1},
                new Empleadoas{ idEmpleado = 3, nombre = "Perengano", idModalidad = 2},
                new Empleadoas{ idEmpleado = 4, nombre = "Sultano", idModalidad = 1},
                new Empleadoas{ idEmpleado = 5, nombre = "Caifan", idModalidad= 2},
                new Empleadoas{ idEmpleado = 6, nombre = "Michelline", idModalidad = 1},
                new Empleadoas{ idEmpleado = 7, nombre = "Alondra", idModalidad = 2},
                new Empleadoas{ idEmpleado = 8, nombre = "Ciwets", idModalidad = 2}

            };

            var Modalidad = listaEmpleados.Select(x => new { x.nombre, x.idModalidad }).OrderBy(x => x.nombre);

            Console.WriteLine("Empleados con Modalidad 1:");
            foreach (var empleado in Modalidad) Console.WriteLine($"Empleado(a): {empleado.nombre}. Modalidad (ID): {empleado.idModalidad}");

        }

        static void ExpresionesLambda3_11()
        {

            List<ModalidadContrato> listaModalidad = new List<ModalidadContrato> {

                new ModalidadContrato{ idModalidad = 1, nombreModalidad = "Indefinido" },
                new ModalidadContrato{ idModalidad = 2, nombreModalidad = "Temporal" }

            };

            List<Empleadoas> listaEmpleados = new List<Empleadoas> {

                new Empleadoas{ idEmpleado = 1, nombre = "Pancho", idModalidad = 2},
                new Empleadoas{ idEmpleado = 2, nombre = "Juancha", idModalidad = 1},
                new Empleadoas{ idEmpleado = 3, nombre = "Perengano", idModalidad = 2},
                new Empleadoas{ idEmpleado = 4, nombre = "Sultano", idModalidad = 1},
                new Empleadoas{ idEmpleado = 5, nombre = "Caifan", idModalidad= 2},
                new Empleadoas{ idEmpleado = 6, nombre = "Michelline", idModalidad = 1},
                new Empleadoas{ idEmpleado = 7, nombre = "Alondra", idModalidad = 2},
                new Empleadoas{ idEmpleado = 8, nombre = "Ciwets", idModalidad = 2}

            };

            var Modalidad = listaEmpleados.Where(x => x.idModalidad == 1).Select(x => x.nombre);

            Console.WriteLine("Empleados con Modalidad 1:");
            foreach (var empleado in Modalidad) Console.WriteLine(empleado);

        }

        static void ExpresionesLambda2_10()
        {
            List<Alumnos> alumnos = new List<Alumnos> {

                new Alumnos { idAlumno = 1, nombreCompleto = "María", cursoFavorito= "PROGRAMACION"},
                new Alumnos { idAlumno = 2, nombreCompleto = "Rogelio", cursoFavorito= "FÍSICA"},
                new Alumnos { idAlumno = 3, nombreCompleto = "Alondra", cursoFavorito= "ÁLGEBRA"},
                new Alumnos { idAlumno = 4, nombreCompleto = "Sebastián", cursoFavorito= "QUÍMICA"},
                new Alumnos { idAlumno = 5, nombreCompleto = "Rolando", cursoFavorito= "BIOLOGÍA"},
                new Alumnos { idAlumno = 6, nombreCompleto = "Benito", cursoFavorito= "INGLÉS"},
                new Alumnos { idAlumno = 7, nombreCompleto = "Juan", cursoFavorito= "LITERATURA"},
                new Alumnos { idAlumno = 8, nombreCompleto = "Alejandra", cursoFavorito= "ELECTRÓNICA"}

            };

            var cursoFav = alumnos.Select(x => $"Su curso favorito es: {x.cursoFavorito}");

            foreach( var fav in cursoFav ) Console.WriteLine( fav );

        }

        static void ExpresionesLambda_9()
        {
            List<Customers> listCustomers = new List<Customers>
            {
                new Customers {nombre = "María", apellido = "Riquelme", ciudad = "CDMX"},
                new Customers {nombre = "Rogelio", apellido = "Santoyo", ciudad = "CD Juárez"},
                new Customers {nombre = "Alondra", apellido = "Palacios", ciudad = "Acapulco"},
                new Customers {nombre = "Sebastián", apellido = "Barrientos", ciudad = "CDMX"},
                new Customers {nombre = "Rolando", apellido = "Mota", ciudad = "Acapulco"},
                new Customers {nombre = "Benito", apellido = "Camelo", ciudad = "CD Juárez"},
                new Customers {nombre = "Juan", apellido = "Gabriel", ciudad = "Acapulco"},
                new Customers {nombre = "Alejandra", apellido = "Marquez", ciudad = "Tijuana"}
            };


            var nombres = listCustomers.Select(x => x.nombre);

            Console.WriteLine("Nombres de empleados: ");
            foreach(var nombre in nombres)Console.WriteLine(nombre);

        }

        static void JoiningCollections3_8()
        {

            List<ModalidadContrato> listaModalidad = new List<ModalidadContrato> {

                new ModalidadContrato{ idModalidad = 1, nombreModalidad = "Indefinido" },
                new ModalidadContrato{ idModalidad = 2, nombreModalidad = "Temporal" }

            };

            List<GeneroEmpleados> Genero = new List<GeneroEmpleados>
            {
                new GeneroEmpleados{ idSexo = 1, Sexo = "Masculino"},
                new GeneroEmpleados{ idSexo = 2, Sexo = "Femenino"}
            };

            List<Empleadoas> listaEmpleados = new List<Empleadoas> {

                new Empleadoas{ idEmpleado = 1, nombre = "Pancho", idModalidad = 2, idSexo = 1},
                new Empleadoas{ idEmpleado = 2, nombre = "Juancha", idModalidad = 1, idSexo = 2},
                new Empleadoas{ idEmpleado = 3, nombre = "Perengano", idModalidad = 2, idSexo = 1},
                new Empleadoas{ idEmpleado = 4, nombre = "Sultano", idModalidad = 1, idSexo = 1},
                new Empleadoas{ idEmpleado = 5, nombre = "Caifan", idModalidad= 2, idSexo = 1},
                new Empleadoas{ idEmpleado = 6, nombre = "Michelline", idModalidad = 1, idSexo = 2},
                new Empleadoas{ idEmpleado = 7, nombre = "Alondra", idModalidad = 2, idSexo = 2},
                new Empleadoas{ idEmpleado = 8, nombre = "Ciwets", idModalidad = 2, idSexo = 1}

            };

            var Union = from modalidad in listaModalidad
                          join empleado in listaEmpleados
                          on modalidad.idModalidad equals empleado.idModalidad
                          join genero in Genero
                          on empleado.idSexo equals genero.idSexo
                          select new { empleado.nombre, modalidad.nombreModalidad, genero = genero.Sexo };

            foreach (var empleado in Union)
            {
                if(empleado.genero == "Masculino") Console.WriteLine($"El empleado {empleado.nombre} es de género: {empleado.genero}, y tiene la modalidad de contrato: {empleado.nombreModalidad}");

                else if( empleado.genero == "Femenino") Console.WriteLine($"La empleada {empleado.nombre} es de género: {empleado.genero}, y tiene la modalidad de contrato: {empleado.nombreModalidad}");

            }


        }

        static void JoiningCollections2_7()
        {
            List<CategoriaProductos> Categorias = new List<CategoriaProductos> 
            {
                new CategoriaProductos { idCategoria = 1, nombreCategoria = "Galletas"},
                new CategoriaProductos { idCategoria = 2, nombreCategoria = "Frituras"},
                new CategoriaProductos { idCategoria = 3, nombreCategoria = "Pan"}
            };

            List<Proveedor> Proveedores = new List<Proveedor> { 
                
                new Proveedor{ idProveedor = 1, nombreProveedor = "Bimbo"},
                new Proveedor{ idProveedor = 2, nombreProveedor = "Sabritas"},
                new Proveedor{ idProveedor = 3, nombreProveedor = "Gamesa"},
                new Proveedor{ idProveedor = 4, nombreProveedor = "Barcel"},
                new Proveedor{ idProveedor = 5, nombreProveedor = "Marinela"},
                new Proveedor{ idProveedor = 6, nombreProveedor = "Tía Rosa"}
            };

            List<Productos> Productos = new List<Productos>
            {
                new Productos{ idProducto = 1, nombre = "Conchas", idCategoria =3, Proveedor = 6},
                new Productos{ idProducto = 2, nombre = "Colchones", idCategoria =3, Proveedor = 1},
                new Productos{ idProducto = 3, nombre = "Mantecadas", idCategoria =3, Proveedor = 1},
                new Productos{ idProducto = 4, nombre = "Nito", idCategoria =3, Proveedor = 1},
                new Productos{ idProducto = 5, nombre = "Gansito", idCategoria =3, Proveedor = 5},

                new Productos{ idProducto = 6, nombre = "Emperador", idCategoria =1, Proveedor = 3},
                new Productos{ idProducto = 7, nombre = "Chokis", idCategoria =1, Proveedor = 3},
                new Productos{ idProducto = 8, nombre = "Galletas María", idCategoria =1, Proveedor = 3},
                new Productos{ idProducto = 9, nombre = "Giro", idCategoria =1, Proveedor = 5},
                new Productos{ idProducto = 10, nombre = "SuaviCremas", idCategoria =1, Proveedor = 3},
                new Productos{ idProducto = 11, nombre = "Tartinas", idCategoria =1, Proveedor = 6},

                new Productos{ idProducto = 12, nombre = "Sabritas", idCategoria =2, Proveedor = 2},
                new Productos{ idProducto = 13, nombre = "Runners", idCategoria =2, Proveedor = 4},
                new Productos{ idProducto = 14, nombre = "Cheetos", idCategoria =2, Proveedor = 2},
                new Productos{ idProducto = 15, nombre = "Tostitos", idCategoria =2, Proveedor = 4},
                new Productos{ idProducto = 16, nombre = "Doritos", idCategoria =2, Proveedor = 2},
                new Productos{ idProducto = 17, nombre = "Crujitos", idCategoria =2, Proveedor = 2}

            };

            var productos = from categorias in Categorias
                            join producto in Productos
                            on categorias.idCategoria equals producto.idCategoria
                            join proveedor in Proveedores
                            on producto.Proveedor equals proveedor.idProveedor
                            orderby categorias.nombreCategoria ascending
                            select new { Cat = categorias.nombreCategoria, nombreP = producto.nombre, proveedor = proveedor.nombreProveedor };
                            
            
            Console.WriteLine("Información de productos:");            
            foreach (var producto in productos) 
                Console.WriteLine($" Producto: ({producto.Cat}) => {producto.nombreP}. Proveedor: {producto.proveedor}.");

        }

        static void JoiningCollections_6()
        {

            List<ModalidadContrato> listaModalidad = new List<ModalidadContrato> {

                new ModalidadContrato{ idModalidad = 1, nombreModalidad = "Cas" },
                new ModalidadContrato{ idModalidad = 2, nombreModalidad = "Temporal" }

            };

            List<Empleado> listaEmpleados = new List<Empleado> { 
            
                new Empleado{ idEmpleado = 1, nombre = "Pancho", idModalidad = 2 },
                new Empleado{ idEmpleado = 2, nombre = "Juancha", idModalidad = 1 },
                new Empleado{ idEmpleado = 3, nombre = "Perengano", idModalidad = 2},
                new Empleado{ idEmpleado = 4, nombre = "Sultano", idModalidad = 1},
                new Empleado{ idEmpleado = 5, nombre = "Caifan", idModalidad= 2},
                new Empleado{ idEmpleado = 6, nombre = "Michelline", idModalidad = 1},
                new Empleado{ idEmpleado = 7, nombre = "Caskey", idModalidad = 2 },
                new Empleado{ idEmpleado = 8, nombre = "Ciwets", idModalidad = 2}

            };

            var joining = from tipo in listaModalidad
                          join empleado in listaEmpleados
                          on tipo.idModalidad equals empleado.idModalidad
                          select new { empleado.nombre, tipo.nombreModalidad };

            foreach (var empleado in joining) Console.WriteLine($"El empleado {empleado.nombre} tiene la modalidad de contrato: {empleado.nombreModalidad}");

        }

        static void AlumnosCalificaciones_5()
        {
            List<Alumnos> alumnos = new List<Alumnos> {

                new Alumnos {nombreCompleto = "María", notas = new List<int>{ 7,8,7,5,4,7,9} },
                new Alumnos {nombreCompleto = "Rogelio", notas = new List<int>{8,7,4,2,6,8,7}},
                new Alumnos {nombreCompleto = "Alondra", notas = new List<int>{5,6,5,4,8,9,7}},
                new Alumnos {nombreCompleto = "Sebastián", notas = new List<int>{4,5,7,8,5,4,9}},
                new Alumnos {nombreCompleto = "Rolando", notas = new List<int>{9,8,5,2,4,7,8}},
                new Alumnos {nombreCompleto = "Benito", notas = new List<int>{9,6,4,7,8,5,2} },
                new Alumnos {nombreCompleto = "Juan", notas = new List<int>{5,6,8,9,7,4,5}},
                new Alumnos {nombreCompleto = "Alejandra", notas = new List<int>{8,9,7,5,6,5,4}}

            };

            var infoAlumno = from alumno in alumnos select $"Alumno: {alumno.nombreCompleto} Primera Nota:{alumno.notas.First()}";

            foreach (var info in infoAlumno) Console.WriteLine(info);

        }

        static void EmpleadosSueldo_4()
        {
            List<Empleados> empleados = new List<Empleados>
            {
                new Empleados {nombre = "María", apellido = "Riquelme", sueldo = 1800},
                new Empleados {nombre = "Rogelio", apellido = "Santoyo", sueldo = 2300},
                new Empleados {nombre = "Alondra", apellido = "Palacios", sueldo = 1300},
                new Empleados {nombre = "Sebastián", apellido = "Barrientos", sueldo = 4000},
                new Empleados {nombre = "Rolando", apellido = "Mota", sueldo = 2000},
                new Empleados {nombre = "Benito", apellido = "Camelo", sueldo = 1900},
                new Empleados {nombre = "Juan", apellido = "Gabriel", sueldo = 3000},
                new Empleados {nombre = "Alejandra", apellido = "Marquez", sueldo = 1500}
            };

            var EP1500 = from empleado in empleados
                         where empleado.sueldo > 1500
                         orderby empleado.apellido ascending
                         select $"Apellido: {empleado.apellido}, Sueldo: ${empleado.sueldo}";

            Console.WriteLine("Empleados que ganan más de 1500,");            
            Console.WriteLine("ordenados por apellido de forma Ascendente: ");

            n();

            foreach(var empleado in EP1500) Console.WriteLine(empleado);

        }

        static void CustomersFiltradoAcapulco_3()
        {

            List<Customers> listCustomers = new List<Customers>
            {             
                new Customers {nombre = "María", apellido = "Riquelme", ciudad = "CDMX"},
                new Customers {nombre = "Rogelio", apellido = "Santoyo", ciudad = "CD Juárez"},
                new Customers {nombre = "Alondra", apellido = "Palacios", ciudad = "Acapulco"},
                new Customers {nombre = "Sebastián", apellido = "Barrientos", ciudad = "CDMX"},
                new Customers {nombre = "Rolando", apellido = "Mota", ciudad = "Acapulco"},
                new Customers {nombre = "Benito", apellido = "Camelo", ciudad = "CD Juárez"},
                new Customers {nombre = "Juan", apellido = "Gabriel", ciudad = "Acapulco"},
                new Customers {nombre = "Alejandra", apellido = "Marquez", ciudad = "Tijuana"}
            };

            var Acapulqueños = from customer in listCustomers where customer.ciudad == "Acapulco" 
                               select new { customer.nombre, customer.apellido };

            Console.WriteLine("Clientes de Acapulco: ");
            foreach (var customer in Acapulqueños) Console.WriteLine($"Nombre / Apellido: {customer.nombre} {customer.apellido}");

        }

        static void NumerosPares_2()
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var numerosPares = from pares in numeros where pares%2 == 0 select pares;
            
            Console.Write("Los números pares son:");

            foreach(var pares in numerosPares) Console.Write($" {pares} ");

            Console.WriteLine();
            Console.WriteLine($"Numero de elementos:{numerosPares.Count()}");
            Console.WriteLine($"Elemento Mayor: {numerosPares.Max()}");
            Console.WriteLine($"Promedio de los elementos:{numerosPares.Average()}");
            Console.WriteLine($"Primer Elemento:{numerosPares.First()}");

        }

        static void NotaAprobatoria_1()
        {

            int[] notas = new int[] { 10, 5, 1, 3, 14, 5, 13, 7, 18, 19, 2 };


            var APROBADOS = from aprobado in notas where aprobado >= 16 select aprobado;

            Console.WriteLine("Notas aprobatorias:");
            foreach (var aprobado in APROBADOS) Console.WriteLine(aprobado);

        }

        static void n() {

            Console.WriteLine("\n");
        }
    }

}
