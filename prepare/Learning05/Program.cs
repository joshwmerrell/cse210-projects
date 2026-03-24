using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning05 World!");

        List<Shape> shapesList = new List<Shape>{};
        shapesList.Add(new Square("Royal Blue"));
        // Shape 1
        //      Color: Royal Blue
        //       Area: 1
        shapesList.Add(new Square(5));
        // Shape 2
        //      Color: yellow
        //       Area: 25
        shapesList.Add(new Square());
        // Shape 3
        //      Color: yellow
        //       Area: 1
        shapesList.Add(new Rectangle("Lavender"));
        // Shape 4
        //      Color: Lavender
        //       Area: 1
        shapesList.Add(new Rectangle(2, 5));
        // Shape 5
        //      Color: red
        //       Area: 10
        shapesList.Add(new Rectangle());
        // Shape 6
        //      Color: red
        //       Area: 1
        shapesList.Add(new Circle("Silvery Mint"));
        // Shape 7
        //      Color: Silvery Mint
        //       Area: 3.14159...
        shapesList.Add(new Circle(3));
        // Shape 8
        //      Color: blue
        //       Area: 28.2743...
        shapesList.Add(new Circle());
        // Shape 9
        //      Color: blue
        //       Area: 3.14159...
        int i = 1;
        foreach (Shape shape in shapesList)
        {
            Console.WriteLine($"Shape {i}:");
            Console.WriteLine($"     Color: {shape.GetColor()}");
            Console.WriteLine($"      Area: {shape.GetArea()}");
            i++;
        }
    }
}