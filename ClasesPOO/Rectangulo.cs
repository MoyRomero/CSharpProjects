using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesPOO
{
    class Rectangulo
    {
        public string color;
        public double altura;
        public double ancho;

        public Rectangulo(string color, double altura, double ancho)
        {
            this.color = color;
            this.altura = altura;
            this.ancho = ancho;

        }

        public double AreaRectangulo()
        {
            return altura * ancho;
        }

        public double PerimRectangulo()
        {
            return (altura * 2) + (ancho * 2);
        }

        public static double PerimRectangulo(double altur, double anch)
        {
            return (altur * 2) + (anch * 2);
        }
    }
}

