using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Shape
    {
        public string Name { get; set; }
        public void PrintName()
        {
            Console.WriteLine($"이 도형은 {Name}입니다.");
        }
    }
    internal class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double GetArea()
        {
            return Width * Height;
        }
    }
    internal class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }
        public double GetArea()
        {
            return (BaseLength * Height) / 2;
        }
    }
    internal class Circle : Shape
    {
        public double Radius { get; set; }
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}