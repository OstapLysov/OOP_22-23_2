using Lab5;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            TPPiramid p1 = new();
            do
            {
                TPPiramid p2;
                System.Console.WriteLine($"Enter the lengths of 3 sides of the pyramid:");
                try
                {
                    p2 = new(Double.Parse(Console.ReadLine()), Double.Parse(Console.ReadLine()), Double.Parse(Console.ReadLine()));
                }
                catch (Exception e)
                {
                    break;
                }
                System.Console.WriteLine($"\nPyramid 1: {p1}");
                System.Console.WriteLine($"Pyramid 2: {p2}");

                System.Console.WriteLine($"\nPerimetr of pyramid 1: {Math.Round(p1.GetPerimeter(), 2)}");
                System.Console.WriteLine($"Area of pyramid 1:     {Math.Round(p1.GetArea(), 2)}\n");
                System.Console.WriteLine($"Volume of pyramid 1:     {Math.Round(p1.GetVolume(), 2)}\n");

                System.Console.WriteLine($"Perimetr of pyramid 2: {Math.Round(p2.GetPerimeter(), 2)}");
                System.Console.WriteLine($"Area of pyramid 2:     {Math.Round(p2.GetArea(), 2)}\n");
                System.Console.WriteLine($"Volume of pyramid 2:     {Math.Round(p2.GetVolume(), 2)}\n");


                System.Console.WriteLine($"Pyramid 1 equals pyramid 2: {p1.Equals(p2)}");

                System.Console.Write("\nPyramid 1 + pyramid 2: ");
                System.Console.WriteLine(p1 + p2);
                System.Console.Write("Pyramid 1 - pyramid 2: ");
                System.Console.WriteLine(p1 - p2);

                System.Console.WriteLine($"\nPyramid 1 * 3,6: {p1 * 3.6}");
                System.Console.WriteLine($"Pyramid 2 * 4:   {p2 * 4}\n\n");

            } while (true);
        }
    }
}