using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    internal class Program
    {


        static void Main(string[] args){

            Figure rectangle = new Rectangle(5, 6);
            Figure triangle = new Triangle(4, 8, 3);

            rectangle.Perimeter();
            triangle.Perimeter();
        }

        abstract class Figure
        {
            public abstract void Perimeter();
        }

        class Rectangle : Figure
        {
            public int width;
            public int height;

            public Rectangle(int width, int height)
            {
                this.width = width;
                this.height = height;
            }

            public override void Perimeter()
            {
                Console.WriteLine((2 * width) + (2 * height));
            }
        }

        class Triangle : Figure
        {
            public int side1;
            public int side2;
            public int side3;

            public Triangle(int s1, int s2, int s3)
            {
                this.side1 = s1;
                this.side2 = s2;
                this.side3 = s3;
            }

            public override void Perimeter()
            {
                Console.WriteLine(side1 + side2 + side3);
            }
        }

    }
}
