using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [];

        Square square = new Square(5);
        square.SetColor("Red");

        Rectangle rect = new Rectangle(5, 25);
        rect.SetColor("Blue");

        Circle circle = new Circle(10.5);
        circle.SetColor("Orange");

        shapes.Add(square);
        shapes.Add(rect);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}