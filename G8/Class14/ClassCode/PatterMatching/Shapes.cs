using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatterMatching
{
    public class Square
    {
        public double Side { get; }
        public Square(double side)
        {
            Side = side;
        }
    }
    public class Circle
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            Radius = radius;
        }
    }

    public class Rectangle
    {
        public int SideA { get; set; }
        public int SideB { get; set; }  
    }

    public class Triangle
    {
        public double Base { get; }
        public double Height { get; }
        public Triangle(double basValue, double height)
        {
            Base = basValue;
            Height = height;
        }
    }

    public class RandomShape
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }
        public double SideD { get; }
        public RandomShape(double sideA, double sideB, double sideC, double sideD)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            SideD = sideD;
        }
    }
}
