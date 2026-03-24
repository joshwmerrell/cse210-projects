using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning05 World!");

        List<Shape> shapesList = new List<Shape>{};
        shapesList.Add(new Square("Royal Blue"));
        shapesList.Add(new Square(5));
        shapesList.Add(new Square());
        shapesList.Add(new Rectangle("Lavender"));
        shapesList.Add(new Rectangle(2, 5));
        shapesList.Add(new Rectangle());
        shapesList.Add(new Circle("Silvery Mint"));
        shapesList.Add(new Circle(3));
        shapesList.Add(new Circle());
        foreach (Shape shape in shapesList)
        {
            shape.GetColor();
            shape.GetArea();
        }
    }
}