using System;

public abstract class Shape
{
    public string Name { get; set; }
    public abstract double CalculateArea();
}

public class Square : Shape
{
    public double Side { get; set; }

    public Square(double side)
    {
        Name = "Square";
        Side = side;
    }

    public override double CalculateArea()
    {
        return Side * Side;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Name = "Rectangle";
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class RightTriangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public RightTriangle(double baseValue, double height)
    {
        Name = "Right Triangle";
        Base = baseValue;
        Height = height;
    }

    public override double CalculateArea()
    {
        return (Base * Height) / 2;
    }
}

class Program
{
    static double ReadPositiveValue(string message)
    {
        double value;
        while (true)
        {
            Console.WriteLine(message);
            if (double.TryParse(Console.ReadLine(), out value) && value > 0)
            {
                return value;  
            }
            else
            {
                Console.WriteLine("Invalid value! Please enter a number greater than zero.");
            }
        }
    }

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - SQUARE");
            Console.WriteLine("2 - RECTANGLE");
            Console.WriteLine("3 - RIGHT TRIANGLE");
            Console.WriteLine("4 - EXIT");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    double square_side = ReadPositiveValue("Enter the side of the square (greater than zero): ");
                    Shape s1 = new Square(square_side);
                    Console.WriteLine($"{s1.Name}: Area = {s1.CalculateArea()}");
                    break;

                case "2":
                    double rectangle_width = ReadPositiveValue("Enter the width of the rectangle (greater than zero): ");
                    double rectangle_height = ReadPositiveValue("Enter the height of the rectangle (greater than zero): ");
                    Shape s2 = new Rectangle(rectangle_width, rectangle_height);
                    Console.WriteLine($"{s2.Name}: Area = {s2.CalculateArea()}");
                    break;

                case "3":
                    double triangle_base = ReadPositiveValue("Enter the base of the right triangle (greater than zero): ");
                    double triangle_height = ReadPositiveValue("Enter the height of the right triangle (greater than zero): ");
                    Shape s3 = new RightTriangle(triangle_base, triangle_height);
                    Console.WriteLine($"{s3.Name}: Area = {s3.CalculateArea()}");
                    break;

                case "4":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}