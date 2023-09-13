using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClasesPOO
{
    class Circulo
    {
        public int radio;
        public Circulo(int radio)
        {
            this.radio = radio;
        }

        public double CalcularCircunferencia()
        {
            return Math.PI * radio * radio;
        }
    }
}
