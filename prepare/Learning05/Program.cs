using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> ShapeList = new List<Shape>();
        ShapeList.Add(new Square("Blue", 5));
        ShapeList.Add(new Rectangle("Red", 2, 6));
        ShapeList.Add(new Circle("Yellow", 10));
        foreach (Shape CurrentShape in ShapeList) {
            Console.WriteLine(CurrentShape.GetColor());
            Console.WriteLine($"{CurrentShape.GetArea()}\n");
        }
    }
}